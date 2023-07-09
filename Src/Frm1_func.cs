using NetLimiter.Service;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static NLMMB.Src.HotKeyManager;
using static NLMMB.Form1;

namespace NLMMB.Src
{
    internal static class Frm1_func
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("psapi.dll")]
        static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] char[] lpBaseName, uint nSize);

        static readonly HotKeyManager _hotkeymanager = new HotKeyManager();

        private static string path;

        public static event EventHandler dl3074;
        public static void Register3074DownHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    dl3074?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler ul3074;
        public static void Register3074UpHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    ul3074?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler dl7500;
        public static void Register7500DownHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    dl7500?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler ul7500;
        public static void Register7500UpHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    ul7500?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler dl27k;
        public static void Register27kDownHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    dl27k?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler ul27k;
        public static void Register27kUpHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    ul27k?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler dl30k;
        public static void Register30kHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    dl30k?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler fullGame;
        public static void RegisterFullGameHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    fullGame?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler blocker;
        public static void RegisterBlockerHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    blocker?.Invoke(sender, args);
                }
            };
        }

        public static event EventHandler gamePause;
        public static void RegisterGamePauseHotKey(ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);

            keyPressed += (sender, args) =>
            {
                if (args.Modkey == modkey && args.Key == key)
                {
                    try
                    {
                        Process process = Process.GetProcessesByName(processName)[0];
                        int processId = process.Id;
                        IntPtr processHandle = Process.GetProcessById(processId).Handle;

                        if (chk1 != true)
                        {
                            chk1 = true;
                            NtSuspendProcess(processHandle);
                        }
                        else
                        {
                            chk1 = false;
                            NtResumeProcess(processHandle);
                        }
                        gamePause?.Invoke(null, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("D2 is not opened");
                    }
                }
            };
        }

        public static void RegisterKCHotKey(string filterName, ModKeys modkey, Keys key)
        {
            _hotkeymanager.RegisterHotKeyNoRepeat(modkey, key);
            EventHandler<KeyPressedEventArgs> localHandler = null;
            localHandler = new EventHandler<KeyPressedEventArgs>((sender, args) =>
            {
                Filter filter = client.Filters.Find(x => x.Name == filterName);
                Rule rule = client.Rules.Find(x => x.FilterId == filter.Id);

                if (args.Modkey == modkey && args.Key == key && filterName == filter.Name)
                {
                    client.KillCnnsByFilterId(client.Filters.Find(x => x.Name == filterName).Id);
                }
            });
            keyPressed += localHandler;
        }

        public static void ObtainD2path()
        {
            IntPtr hProcess = OpenProcess(0x0400 | 0x0010, false, processId);
            if (hProcess == IntPtr.Zero)
            {

            }
            const int MAX_PATH = 260;
            char[] buffer = new char[MAX_PATH];
            uint result = GetModuleFileNameEx(hProcess, IntPtr.Zero, buffer, MAX_PATH);
            if (result != 0)
            {
                path = new string(buffer, 0, (int)result);
            }
        }

        public static void DisposeAndCreateFilters()
        {
            new D2FilterRule(client, path, "Destiny 2", RuleDir.In, settings.bpslfg, 80, 30010);
            new D2FilterRule(client, path, "3074 Down", RuleDir.Out, settings.dlbps3074, 3074, 3074);
            new D2FilterRule(client, path, "3074 Up", RuleDir.Out, settings.ulbps3074, 3074, 3074);
            new D2FilterRule(client, path, "7500 Down", RuleDir.In, settings.dlbps7500, 7500, 7509);
            new D2FilterRule(client, path, "7500 Up", RuleDir.Out, settings.ulbps7500, 7500, 7509);
            new D2FilterRule(client, path, "27k Down", RuleDir.In, settings.dlbps27k, 27015, 27200);
            new D2FilterRule(client, path, "27k Up", RuleDir.Out, settings.ulbps27k, 27015, 27200);
            new D2FilterRule(client, path, "30k", RuleDir.In, settings.bps30k, 30000, 30010);
            new D2BlockRule(client, path, "PvP Limit", RuleDir.Both, 27015, 27200);
        }

        public static void DisposeAndCreateFilters(uint bpslfg, uint dlbps3074, uint ulbps3074, uint dlbps7500, uint ulbps7500, uint dlbps27k, uint ulbps27k, uint bps30k)
        {
            new D2FilterRule(client, path, "Destiny 2", RuleDir.In, bpslfg, 80, 30010);
            new D2FilterRule(client, path, "3074 Down", RuleDir.Out, dlbps3074, 3074, 3074);
            new D2FilterRule(client, path, "3074 Up", RuleDir.Out, ulbps3074, 3074, 3074);
            new D2FilterRule(client, path, "7500 Down", RuleDir.In, dlbps7500, 7500, 7509);
            new D2FilterRule(client, path, "7500 Up", RuleDir.Out, ulbps7500, 7500, 7509);
            new D2FilterRule(client, path, "27k Down", RuleDir.In, dlbps27k, 27015, 27200);
            new D2FilterRule(client, path, "27k Up", RuleDir.Out, ulbps27k, 27015, 27200);
            new D2FilterRule(client, path, "30k", RuleDir.In, bps30k, 30000, 30010);
            new D2BlockRule(client, path, "PvP Limit", RuleDir.Both, 27015, 27200);
        }

        public static void GetHotKeySettings()
        {
            if (settings.hotkeydl3074 == true)
            {
                Register3074DownHotKey(settings.modkeydl3074, settings.keydl3074);
            }
            if (settings.hotkeyul3074 == true)
            {
                Register3074UpHotKey(settings.modkeyul3074, settings.keyul3074);
            }
            if (settings.hotkeydl7500 == true)
            {
                Register7500DownHotKey(settings.modkeydl7500, settings.keydl7500);
            }
            if (settings.hotkeyul7500 == true)
            {
                Register7500UpHotKey(settings.modkeyul7500, settings.keyul7500);
            }
            if (settings.hotkeydl27k == true)
            {
                Register27kDownHotKey(settings.modkeydl27k, settings.keydl27k);
            }
            if (settings.hotkeyul27k == true)
            {
                Register27kUpHotKey(settings.modkeyul27k, settings.keyul27k);
            }
            if (settings.hotkeygp == true)
            {
                RegisterGamePauseHotKey(settings.modkeygp, settings.keygp);
            }
            if (settings.hotkeypvpl == true)
            {
                RegisterBlockerHotKey(settings.modkeypvpl, settings.keypvpl);
            }
            if (settings.hotkey30kkc == true)
            {
                RegisterKCHotKey("30k", settings.modkey30kkc, settings.key30kkc);
            }
            if (settings.hotkeylfg == true)
            {
                RegisterFullGameHotKey(settings.modkeylfg, settings.keylfg);
            }
            if (settings.hotkeypvel == true)
            {
                RegisterKCHotKey("7500 Down", settings.modkeypvel, settings.keypvel);
            }
            if (settings.hotkey30kl == true)
            {
                Register30kHotKey(settings.modkey30kl, settings.key30kl);
            }
        }

        public static void GetHotKeySettings(params object[] hotkeyArray)
        {
            if (hotkeyArray[0] is bool && (bool)hotkeyArray[0])
            {
                Register3074DownHotKey((ModKeys)hotkeyArray[1], (Keys)hotkeyArray[2]);
            }
            if (hotkeyArray[3] is bool && (bool)hotkeyArray[3])
            {
                Register3074UpHotKey((ModKeys)hotkeyArray[4], (Keys)hotkeyArray[5]);
            }
            if (hotkeyArray[6] is bool && (bool)hotkeyArray[6])
            {
                Register7500DownHotKey((ModKeys)hotkeyArray[7], (Keys)hotkeyArray[8]);
            }
            if (hotkeyArray[9] is bool && (bool)hotkeyArray[9])
            {
                Register7500UpHotKey((ModKeys)hotkeyArray[10], (Keys)hotkeyArray[11]);
            }
            if (hotkeyArray[12] is bool && (bool)hotkeyArray[12])
            {
                Register27kDownHotKey((ModKeys)hotkeyArray[13], (Keys)hotkeyArray[14]);
            }
            if (hotkeyArray[15] is bool && (bool)hotkeyArray[15])
            {
                Register27kUpHotKey((ModKeys)hotkeyArray[16], (Keys)hotkeyArray[17]);
            }
            if (hotkeyArray[18] is bool && (bool)hotkeyArray[18])
            {
                RegisterGamePauseHotKey((ModKeys)hotkeyArray[19], (Keys)hotkeyArray[20]);
            }
            if (hotkeyArray[21] is bool && (bool)hotkeyArray[21])
            {
                RegisterBlockerHotKey((ModKeys)hotkeyArray[22], (Keys)hotkeyArray[23]);
            }
            if (hotkeyArray[24] is bool && (bool)hotkeyArray[24])
            {
                RegisterKCHotKey("30k", (ModKeys)hotkeyArray[25], (Keys)hotkeyArray[26]);
            }
            if (hotkeyArray[27] is bool && (bool)hotkeyArray[27])
            {
                RegisterFullGameHotKey((ModKeys)hotkeyArray[28], (Keys)hotkeyArray[29]);
            }
            if (hotkeyArray[30] is bool && (bool)hotkeyArray[30])
            {
                RegisterKCHotKey("7500 Down", (ModKeys)hotkeyArray[31], (Keys)hotkeyArray[32]);
            }
            if (hotkeyArray[33] is bool && (bool)hotkeyArray[33])
            {
                Register30kHotKey((ModKeys)hotkeyArray[34], (Keys)hotkeyArray[35]);
            }
        }

        public static void RemoveAllHotKeys()
        {
            _hotkeymanager.Dispose();
        }
    }
}