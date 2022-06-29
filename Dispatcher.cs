using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plane
{
    class Dispatcher
    {
        Rectangle whether_location; // где будут плохие погодные условия 
        Rectangle location_of_dispatcher; // где сидит диспетчер
        int recommend_speed; //рекомендуемая скорость в соответсвие с погодными условиями
        int recommend_height;//рекомендуемая высота в соответсвие с погодными условиями
        string name;

        Random rand = new Random();
        Dispatcher()
        {
            //рандомим облать плохих погодных условий
            whether_location.X = rand.Next(-40, 1045); 
            whether_location.Y = rand.Next(400, 540);
        }
    }
}
