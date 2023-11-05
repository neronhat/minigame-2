public enum element {None,Fire,ice,Lighting,Dark}

namespace elementsystem
{
    public class Element
    {
        public static float logicelement(element ele,element ele2)
        {
            string result;
            float ratioDmg=0;
           switch (ele)
            {
                case element.None: { result = "";ratioDmg=1;break; }
                case element.Fire: {
                        switch(ele2)
                        {
                            case element.ice: { result = "weak";ratioDmg=0.7f; break;}
                            case element.Lighting: { result = ""; ratioDmg = 1f; break; }
                            case element.Dark: { result = "strong"; ratioDmg = 1.3f; break; }
                            case element.Fire: { result = ""; ratioDmg = 1f; break; }
                            case element.None: { result = "strong"; ratioDmg = 1.3f; break; }
                        }

                        break; }
                case element.ice:
                    {
                        switch (ele2)
                        {
                            case element.ice: { result = ""; ratioDmg = 1f; break; }
                            case element.Lighting: { result = "weak"; ratioDmg = 0.7f; break; }
                            case element.Dark: { result = ""; ratioDmg = 1f; break; }
                            case element.Fire: { result = "strong"; ratioDmg = 1.3f; break; }
                            case element.None: { result = "strong"; ratioDmg = 1.3f; break; }
                        }

                        break;
                    }
                case element.Lighting:
                    {
                        switch (ele2)
                        {
                            case element.ice: { result = "strong"; ratioDmg = 1.3f; break; }
                            case element.Lighting: { result = ""; ratioDmg = 1f; break; }
                            case element.Dark: { result = "weak"; ratioDmg = 0.7f; break; }
                            case element.Fire: { result = ""; ratioDmg = 1f; break; }
                            case element.None: { result = "strong"; ratioDmg = 1.3f; break; }
                        }

                        break;
                    }
                case element.Dark:
                    {
                        switch (ele2)
                        {
                            case element.ice: { result = ""; ratioDmg = 1f; break; }
                            case element.Lighting: { result = "strong"; ratioDmg = 1.3f; break; }
                            case element.Dark: { result = ""; ratioDmg = 1f; break; }
                            case element.Fire: { result = "weak"; ratioDmg = 0.7f; break; }
                            case element.None: { result = "strong"; ratioDmg = 1.3f; break; }
                        }

                        break;
                    }
            }
            return ratioDmg;
        }
            
    }
}