using KinoRakendus.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinoRakendus.forms.main.pages;
using KinoRakendus.core.enums;
using KinoRakendus.core.controls;
using KinoRakendus.core.utils;
namespace KinoRakendus.core.presets
{
    public static class DefaultPageTemplates
    {
        public static List<PageDataTemplate> Templates { get; set; } = new List<PageDataTemplate>()
        { 
            new PageDataTemplate(new Kava(), Rolls.User, HeaderButtonType.Default, buttonName: "Kava", icon:DefaultImages.GetHomeIcon()),
            new PageDataTemplate(new Piletid(), Rolls.User, HeaderButtonType.Default, buttonName:"Piletid", icon:DefaultImages.GetTicketsIcon()),
            new PageDataTemplate(new Filmid(), Rolls.Admin, HeaderButtonType.Default, buttonName:"Filmid", icon:DefaultImages.GetMoviesIcon()),
            new PageDataTemplate(new Kasutajad(), Rolls.Admin, HeaderButtonType.Default, buttonName:"Kasutajad", icon:DefaultImages.GetUsersIcon()),
            new PageDataTemplate(new Seansid(), Rolls.Admin, HeaderButtonType.Default, buttonName:"Seansid", icon:DefaultImages.GetSessionIcon()),
            new PageDataTemplate(new Zanrid(), Rolls.Admin, HeaderButtonType.Default, buttonName:"Zanrid", icon:DefaultImages.GetGenreIcon()),
            new PageDataTemplate(new Saalid(), Rolls.Admin, HeaderButtonType.Default, buttonName:"Saalid", icon:DefaultImages.GetHallIcon())
        };

        public static HeaderButton GetButton(PageDataTemplate pdt)
        {
            Console.WriteLine($"GetButton, {pdt.Page}");

            return new HeaderButton(pdt.Page, pdt.Type, pdt.ButtonName, image: pdt.Icon);
        }
        public static List<HeaderButton> GetButtons(Rolls role)
        {
            List<HeaderButton> returnList = new List<HeaderButton>();
            foreach(PageDataTemplate template in Templates)
            {
                if(template.Role == role)
                {
                    HeaderButton button = GetButton(template);
                    Console.WriteLine($"DAVAJ OSTANOVIMSA {button.Page}");
                    returnList.Add(button);
                }
            }
            return returnList;
        }
    }
}
