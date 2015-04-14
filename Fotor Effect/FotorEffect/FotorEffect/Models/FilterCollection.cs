using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotorEffect.Models
{
    public class FilterCollection
    {
        public List<List<FilterModel>> FilterList { get; set; }
      
        public FilterCollection()
        {
            FilterList = new List<List<FilterModel>>();

            List<FilterModel> list1 = new List<FilterModel>();
            List<FilterModel> list2 = new List<FilterModel>();
            List<FilterModel> list3 = new List<FilterModel>();
            List<FilterModel> list4 = new List<FilterModel>();
            List<FilterModel> list5 = new List<FilterModel>();


            list1.Add(new AntiqueFilterModel());
            list1.Add(new AutoEnhanceFilterModel());
            list1.Add(new AutoLevelsFilterModel());
            list1.Add(new BlurFilterModel());
            list1.Add(new BrightnessFilterModel());
            list1.Add(new CartoonFilterModel());
            list1.Add(new ChromaKeyFilterModel());
            list1.Add(new ColorBoostFilterModel());

            list2.Add(new ColorizationFilterModel());
            list2.Add(new ContrastFilterModel());
            list2.Add(new CurvesFilterModel());
            list2.Add(new DespeckleFilterModel());
            list2.Add(new ExposureFilterModel());
            list2.Add(new FlipFilterModel());
            list2.Add(new FogFilterModel());

            list3.Add(new EmbossFilterModel());
            list3.Add(new FoundationFilterModel());
            list3.Add(new GrayscaleFilterModel());
            list3.Add(new GrayscaleNegativeFilterModel());
            list3.Add(new HueSaturationFilterModel());
            list3.Add(new LevelsFilterModel());
            list3.Add(new LocalBoostFilterModel());
            list3.Add(new LomoFilterModel());
            list3.Add(new MagicPenFilterModel());
            list3.Add(new MilkyFilterModel());
            list3.Add(new MirrorFilterModel());
            list3.Add(new MonocolorRedFilterModel());
            list3.Add(new MonocolorGreenFilterModel());
            list3.Add(new NegativeFilterModel());
            
            list4.Add(new MonocolorBlueFilterModel());
            list4.Add(new MoonlightFilterModel());
            list4.Add(new NoiseFilterModel());
            list4.Add(new OilyFilterModel());
            list4.Add(new PaintFilterModel());
            list4.Add(new PosterizeFilterModel());
            list4.Add(new SepiaFilterModel());
            list4.Add(new SharpnessFilterModel());

            list5.Add(new SketchFilterModel());
            list5.Add(new SolarizeFilterModel());
            list5.Add(new WarpTwisterFilterModel());
            list5.Add(new WatercolorFilterModel());
            list5.Add(new VignettingFilterModel());
            list5.Add(new TemperatureAndTintFilterModel());
            list5.Add(new WhiteboardEnhancementFilterModel());

            FilterList.Add(list1);
            FilterList.Add(list2);
            FilterList.Add(list3);
            FilterList.Add(list4);
            FilterList.Add(list5);
            //Cannot use
            //FilterList.Add(new ImageFusionFilterModel());
            // FilterList.Add(new StampFilterModel());
            //FilterList.Add(new BlendFilterModel());
        }
    }
}
