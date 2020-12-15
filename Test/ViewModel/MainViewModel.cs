using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Documents;
using GalaSoft.MvvmLight.Command;
using System;
using Test.TechModel;
using System.IO;
using System.Linq;

namespace Test.ViewModel
{
  
    public class MainViewModel : ViewModelBase
    {

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { 
                _Id = value;
                RaisePropertyChanged(); }
        }

        #region 材料选择

 
        public List<TechMaterials>  TechMaterials { get; set; }

        private TechMaterials _SelectTechMateIndex;

        public TechMaterials SelectTechMateIndex
        {
            get { return _SelectTechMateIndex; }
            set { _SelectTechMateIndex = value;RaisePropertyChanged(); }
        }
        #endregion

        #region 气体选择
        public List<GasModel> GasModels { get; set; }

        private GasModel _SelectGasIndex;
        public GasModel SelectGasIndex
        {
            get { return _SelectGasIndex; }
            set { _SelectGasIndex = value;RaisePropertyChanged(); }
        }
        #endregion

        #region 厚度
        private List<string> _ThicknessList;

        public List<string> ThicknessList
        {
            get { return _ThicknessList; }
            set { _ThicknessList = value;RaisePropertyChanged(); }
        }


        private string _SelectThicknessIndex = string.Empty;

        public string SelectThicknessIndex
        {
            get { return _SelectThicknessIndex; }
            set { _SelectThicknessIndex = value;RaisePropertyChanged(); }
        }
        #endregion

        public RelayCommand<TechMaterials> TechChangedCommnad { get; set; }

        public RelayCommand<string> TechThicknessChangedCommnad { get; set; }

        public RelayCommand<TechnologyInfo> SelectTechnologyInfoCommand { get; set; }

        public readonly  List<TechnologyInfo> _TechnologyRecList = new List<TechnologyInfo>(); //工艺配方数据源

        private TechnologyInfo _CurrentTechnologyInfo;

        public TechnologyInfo CurrentTechnologyInfo
        {
            get { return _CurrentTechnologyInfo; }
            set { _CurrentTechnologyInfo = value;RaisePropertyChanged(); }
        }

        private List<TechnologyInfo> _GetTechnologyInfos;

        public List<TechnologyInfo> GetTechnologyInfos
        {
            get { return _GetTechnologyInfos; }
            set { _GetTechnologyInfos = value;RaisePropertyChanged(); }
        }

        private TechnologyInfo _SelectTechnologyInfo;

        public TechnologyInfo SelectTechnologyInfo
        {
            get { return _SelectTechnologyInfo; }
            set { _SelectTechnologyInfo = value;RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            TechMaterials = new List<TechMaterials>();
            GasModels = new List<GasModel>();
            ThicknessList = new List<string>();
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 0, Cb_MaterialsName = "全部" });
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 1, Cb_MaterialsName = "不锈钢" });
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 2, Cb_MaterialsName = "碳钢" });
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 3, Cb_MaterialsName = "钛合金" });
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 4, Cb_MaterialsName = "铝合金" });
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 5, Cb_MaterialsName = "紫铜" });
            TechMaterials.Add(new ViewModel.TechMaterials() { Cb_MaterialsID = 6, Cb_MaterialsName = "黄铜" });
            SelectTechMateIndex = TechMaterials[0];
            TechChangedCommnad = new RelayCommand<TechMaterials>((o) => TechChangedCommnadClick(o));
            TechThicknessChangedCommnad = new RelayCommand<string>(o => TechThicknessChangedCommnadClick(o));
            SelectTechnologyInfoCommand = new RelayCommand<TechnologyInfo>(o => SelectTechnologyInfoCommandClick(o));
            RregisterTechnologyRecList();
            GetTechnologyInfos = _TechnologyRecList;
            RefreshThickness();
        }

        private void SelectTechnologyInfoCommandClick(TechnologyInfo o)
        {
            
        }

        void RefreshThickness()
        {
            ThicknessList = GetTechnologyInfos.OrderBy(m => Convert.ToDouble(m.ThicknessInfo == "" ? 0 : Convert.ToDouble(m.ThicknessInfo))).Select(p => p.ThicknessInfo).Distinct().ToList();
            ThicknessList.Insert(0, "全部");
            SelectThicknessIndex = ThicknessList[0];
        }
        private void TechThicknessChangedCommnadClick(string o)
        {
            if (o == null) return;
            if (SelectTechMateIndex.Cb_MaterialsID == 0&& o.Equals("全部")) { GetTechnologyInfos = _TechnologyRecList; return; }
            if (o.Equals("全部"))
                GetTechnologyInfos = _TechnologyRecList.Where(c => c.MaterialsID == SelectTechMateIndex.Cb_MaterialsID).ToList();
            else
                GetTechnologyInfos = _TechnologyRecList.Where(m => m.ThicknessInfo.Equals(o)).ToList();
        }
        public  void RregisterTechnologyRecList()
        {
            _TechnologyRecList.Clear();
           
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory+ "TechFile", "*.xml");
            if (files.Count() == 0) return;
            for (int i = 0; i < files.Length; i++)
            {
                TechnologyInfo _tobj = CommonFunTool.SerializerXMLToObject<TechnologyInfo>(files[i]);
                if (_tobj != null)
                    if (_TechnologyRecList.Count > 0)
                    {
                        while (true)
                        {
                            if (_TechnologyRecList.Where(o => o.QuiqueCode == _tobj.QuiqueCode).Count() > 0)
                            {
                                _tobj.QuiqueCode = Guid.NewGuid().ToString();
                            }
                            else
                            {
                                _TechnologyRecList.Add(_tobj);
                                CommonFunTool.SerializeToXmlFile<TechnologyInfo>(_tobj, files[i]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        _TechnologyRecList.Add(_tobj);
                    }

            }
        }
        private void TechChangedCommnadClick(TechMaterials o)
        {
            if (o.Cb_MaterialsID == 0) { GetTechnologyInfos = _TechnologyRecList; RefreshThickness(); return; }
            if (SelectThicknessIndex.Equals("全部"))
                GetTechnologyInfos = _TechnologyRecList.Where(c => c.MaterialsID == o.Cb_MaterialsID).ToList();
            else if(SelectThicknessIndex!="")
            GetTechnologyInfos = _TechnologyRecList.Where(c => c.MaterialsID == o.Cb_MaterialsID&&c.ThicknessInfo.Equals(SelectThicknessIndex)).ToList();
            else
                GetTechnologyInfos = _TechnologyRecList.Where(c => c.MaterialsID == o.Cb_MaterialsID).ToList();
            RefreshThickness();
        }
    }

    public class TechMaterials
    {
        private int cb_MaterialsID;
        public int Cb_MaterialsID
        {
            get { return cb_MaterialsID; }
            set { cb_MaterialsID = value; }
        }

        private string cb_MaterialsName;
        public string Cb_MaterialsName
        {
            get { return cb_MaterialsName; }
            set { cb_MaterialsName = value; }
        }
    }

 

    public class GasModel
    {
        private int cb_GasID;
        public int Cb_GasID
        {
            get { return cb_GasID; }
            set { cb_GasID = value; }
        }

        private string cb_GasName;
        public string Cb_GasName
        {
            get { return cb_GasName; }
            set { cb_GasName = value; }
        }
    }
}