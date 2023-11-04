﻿using ClassicUO.Assets;
using ClassicUO.Game.UI.Controls;
using Microsoft.Xna.Framework;

namespace ClassicUO.Game.UI.Gumps
{
    internal class VersionHistory : Gump
    {
        private static string[] updateTexts = {
            "/c[white][3.10.0]/cd\n" +
                "- Added the option to download a spell indicator config from an external source\n" +
                "- Added a simple auto loot system\n" +
                "- Updated to ClassicUO's latest version\n" +
                "- Auto sort is container specific now\n" +
                "- InfoBar can now be resized and is using the new font rendering system\n" +
                "- InfoBar font and font size can be customized now (TazUO->Misc)\n" +
                "- Journal will now remember the last tab you were on",

            "/c[white][3.9.0]/cd\n" +
                "- Added missing race change gump\n" +
                "- If no server is set in settings.json user will get a request to type one in\n" +
                "- When opening TUO with a uo directory that is not valid a folder selection prompt will open\n" +
                "- Spell indicator system, see wiki for more details\n" +
                "- The /c[green]-marktile/cd command works on static locations also now\n" +
                "- The 'Items Only' option for nameplates will no longer include corpses\n" +
                "- Bug fix for object highlighting\n" +
                "- Bug fix for <BR> tag in tooltips",

            "/c[white][3.8.0]/cd\n" +
                "- Added sound override feature\n" +
                "- Added -radius command, see wiki for more details\n" +
                "- Added an optional skill progress bar when a skill changes\n",

            "/c[white][3.7.1]/cd\n" +
                "- Added ability to sort advanced skills gump by lock status\n" +
                "- Added import and export options for Grid Highlight settings\n" +
                "- Added a simple account selector on the login screen\n" +
                "- Added a toggle to auto sort grid containers\n" +
                "- Trees/stumps will be slightly visible with circle of transparency on\n" +
                "- Multi item move can now move items to the trade window\n" +
                "- Added -marktile command, see wiki for more details\n" +
                "- Updated TUO with CUO updates\n" +
                "- Fixed mouse interactions with art replaced using the PNG replacement system\n" +
                "- Advanced Skill Gump light support for groups added by Elderwyn\n" +
                "- Fix for backpack not loading contents when logging in\n" +
                "- Text width fix for old clients\n" +
                "- Fix for a potential small memory leak - Lasheras\n" +
                "- Fix for a bug when creating a new character\n" +
                "- Potential fix for bug when processing messages\n" +
                "- Fixed an issue on OSI where corpses would not open in grid containers\n" +
                "- Fix for some SOS messages\n" +
                "- Fix for text not being clickable\n" +
                "- Added yellow highlighting for overhead text",

            "/c[white][3.7.0]/cd\n" +
                "- Updated some default font sizes, slightly larger (New installs only)\n" +
                "- Added item count to grid containers\n" +
                "- Changed health lines back to blue\n" +
                "- Added boat control gump\n" +
                "- Fixed + symbol issue with tooltip overrides\n" +
                "- Fixed an issue with having zero tooltip overrides\n" +
                "- Fixed journal width issue when timestamps are disabled\n" +
                "- Added {3} to tooltip overrides, inserting the original tooltip property",

            "/c[white][3.6.0]/cd\n" +
                "- Tooltip import crash fix\n" +
                "- Tooltip delete all override button added\n" +
                "- Tooltip override color fix\n" +
                "- Added an error message when importing tooltip override fails\n" +
                "- Fixed tooltip background hue offset",

            "/c[white][3.5.0]/cd\n" +
                "- Bug fix for EA egg event\n" +
                "- Added tooltip header formatting(change item name color)\n" +
                "- Damage hues fixed\n" +
                "- Added fix for <h2> and <Bodytextcolor> tags\n" +
                "- Tooltip crash fix\n" +
                "- Added tooltip export and import buttons\n" +
                "- Updated to the main CUO repo",

            "/c[white][3.4.0]/cd\n" +
                "- Added this version history gump\n" +
                "- Added /c[green]-version/cd command to open this gump\n" +
                "- Made advanced skill gump more compact, height resizable and can grab skill buttons by dragging skills\n" +
                "- Added tooltip override feature (See wiki for more details)\n" +
                "- Better rain\n" +
                "- Fixed tooltips in vendor search\n" +
                "- Fixed modern shop gump displaying wrong items at animal trainers\n" +
                "- Added hide border and timestamps to journal options\n" +
                "- Added hide border option for grid containers",

            "/c[white][3.3.0]/cd\n" +
                "-Last attack automatic healthbar gump will remember its position\n" +
                "-Nameplate gump now has a search option (Ctrl + Shift)\n"+
                "-Fix number(gold) entry for trading gump\n"+
                "-Fixed red warmode outline for custom health gumps\n"+
                "-Graphics in info bar -> See wiki\n"+
                "-Tooltip background colors adjustable\n"+
                "-Tmap and SOS right click menu moved to menu icon on gump\n"+
                "- \"/c[green]-skill /c[white]skillname/cd\" command added to use skills\n",
            "\n\n/c[white]For further history please visit our discord."
        };

        public VersionHistory() : base(0, 0)
        {
            X = 300;
            Y = 200;
            Width = 400;
            Height = 500;
            CanCloseWithRightClick = true;
            CanMove = true;

            BorderControl bc = new BorderControl(0, 0, Width, Height, 36);
            bc.T_Left = 39925;
            bc.H_Border = 39926;
            bc.T_Right = 39927;
            bc.V_Border = 39928;
            bc.V_Right_Border = 39930;
            bc.B_Left = 39931;
            bc.B_Right = 39933;
            bc.H_Bottom_Border = 39932;

            Add(new GumpPicTiled(39929) { X = bc.BorderSize, Y = bc.BorderSize, Width = Width - (bc.BorderSize * 2), Height = Height - (bc.BorderSize * 2) });

            Add(bc);

            TextBox _;
            Add(_ = new TextBox("TazUO Version History", TrueTypeLoader.EMBEDDED_FONT, 30, Width, Color.White, FontStashSharp.RichText.TextHorizontalAlignment.Center, false) { Y = 10 });
            Add(_ = new TextBox("Current Version: " + CUOEnviroment.Version.ToString(), TrueTypeLoader.EMBEDDED_FONT, 20, Width, Color.Orange, FontStashSharp.RichText.TextHorizontalAlignment.Center, false) { Y = _.Y + _.Height + 5 });

            ScrollArea scroll = new ScrollArea(10, _.Y + _.Height, Width - 20, Height - (_.Y + _.Height) - 20, true) { ScrollbarBehaviour = ScrollbarBehaviour.ShowAlways };

            Add(new AlphaBlendControl(0.45f) { Width = scroll.Width, Height = scroll.Height, X = scroll.X, Y = scroll.Y });

            int y = 0;
            foreach (string s in updateTexts)
            {
                scroll.Add(_ = new TextBox(s, TrueTypeLoader.EMBEDDED_FONT, 15, scroll.Width - scroll.ScrollBarWidth(), Color.Orange, FontStashSharp.RichText.TextHorizontalAlignment.Left, false) { Y = y });
                y += _.Height + 10;
            }

            Add(scroll);


            HitBox _hit;
            Add(_ = new TextBox("TazUO Wiki", TrueTypeLoader.EMBEDDED_FONT, 15, 200, Color.Orange, strokeEffect: false) { X = 25, Y = Height - 20 });
            Add(_hit = new HitBox(_.X, _.Y, _.MeasuredSize.X, _.MeasuredSize.Y));
            _hit.MouseUp += (s, e) =>
            {
                Utility.Platforms.PlatformHelper.LaunchBrowser("https://github.com/bittiez/ClassicUO/wiki");
            };

            Add(_ = new TextBox("TazUO Discord", TrueTypeLoader.EMBEDDED_FONT, 15, 200, Color.Orange, strokeEffect: false) { X = 280, Y = Height - 20 });
            Add(_hit = new HitBox(_.X, _.Y, _.MeasuredSize.X, _.MeasuredSize.Y));
            _hit.MouseUp += (s, e) =>
            {
                Utility.Platforms.PlatformHelper.LaunchBrowser("https://discord.gg/SqwtB5g95H");
            };
        }
    }
}