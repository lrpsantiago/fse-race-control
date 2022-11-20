private const int CHECKPOINT_COUNT = 2;
private const int RACE_LAPS = 99;
private const int START_LIGHTS_COUNT = 5;
private const int TIME_PER_LIGHT = 1000;
private const int START_LIGHTS_STARTUP_TIME = 10000;
private const int START_LIGHTS_OUT_TIME_MIN = 1000;
private const int START_LIGHTS_OUT_TIME_MAX = 1001;
private readonly string MAIN_LCD_NAME = "Race Main LCD";
private readonly string LAPS_LCD_NAME = "Race Laps LCD";
private readonly string SPEEDTRAP_LCD_NAME = "Race Speedtrap LCD";
private readonly string FASTEST_LAPS_LCD_NAME = "Race Fastest Laps LCD";
private readonly string START_FINISH_SENSOR_NAME = "Start/Finish Sensor";
private readonly string CHECKPOINT_SENSOR_PREFIX = "Checkpoint Sensor ";
private readonly string START_LIGHTS_PREFIX = "Start Lights ";
private readonly string START_LIGHTS_GO = "Start Lights Go";
private readonly string LAP_COUNTERS_GROUP_NAME = "Lap Counter LCDs";
private readonly string PIT_ENTRY_SENSOR_NAME = "Pit Entry Sensor";
private readonly string PIT_EXIT_SENSOR_NAME = "Pit Exit Sensor";
private const int DISPLAY_WIDTH = 38;
private const int BROADCAST_COOLDOWN = 1000;

enum ú{û,ü,þ}enum ù{ß,ê,à,á}string â="7.1.0";IMyTextPanel ã;IMyTextPanel ä;IMyTextPanel å;IMyTextPanel æ;List<
IMyTextPanel>ç;IMySensorBlock è;IList<IMySensorBlock>é=new List<IMySensorBlock>();IMySensorBlock ë;IMySensorBlock ö;IList<
IEnumerable<IMyLightingBlock>>ì=new List<IEnumerable<IMyLightingBlock>>();IEnumerable<IMyLightingBlock>í;Dictionary<string,ĉ>î=new
Dictionary<string,ĉ>();List<MyDetectedEntityInfo>ï=new List<MyDetectedEntityInfo>();StringBuilder ð;Dictionary<string,long>ñ;List<
ĉ>ò=new List<ĉ>();ù ó=ù.ß;ú ô;bool õ;long ý;int ø;int ÿ;int Ĉ;class ĉ{public string Ċ{get;set;}public int ċ{get;set;}
public long?Č{get;set;}public long č{get;set;}public IList<TimeSpan>Ď{get;set;}=new List<TimeSpan>();public bool[]ď{get;set;}=
new bool[CHECKPOINT_COUNT];public int Đ{get{return Ď.Count;}}public TimeSpan đ{get{return new TimeSpan(DateTime.Now.Ticks-č
);}}public TimeSpan Ē{get{return Ď.Count>0?Ď.Last():TimeSpan.Zero;}}public TimeSpan ē{get{return Ď.Count>0?Ď.Min():
TimeSpan.MaxValue;}}public TimeSpan Ĕ{get{return new TimeSpan(Ď.Select(ĕ=>ĕ.Ticks).Sum());}}}Program(){ñ=new Dictionary<string,
long>();ð=new StringBuilder();Runtime.UpdateFrequency=UpdateFrequency.Update1;try{Ø();Û("Initializing Race Script...\n");Û(
"Detecting LCDs.................");Ì();Û("OK!\n");Û("Detecting Sensors..............");Î();Û("OK!\n");Û("Detecting Start Lights.........");Ñ();Û("OK!\n")
;Ę("FREE");Û("Waiting for players...\n");}catch(Exception e){Û("\nError: "+e.Message);}N();}void Save(){}void Main(string
Ė,UpdateType ė){Echo($"Running FSE Race Control {â}+");Ę(Ė);ª();µ();ę();Ā();Ą();Ć();ć();b();g();q();}void Ę(string Ė){
switch(Ė){case"RACE":Ú();õ=true;ô=ú.û;Ý("Race Mode!\n");break;case"QUALI":Ú();ô=ú.ü;Ý("Quilifying Mode!\n");break;case"FREE":Ú
();ô=ú.þ;Ý("Free Practice Mode!\n");break;case"FLAG_G":ó=ù.ß;break;case"FLAG_Y":ó=ù.ê;break;case"FLAG_R":ó=ù.à;break;
default:break;}}void ę(){if(!õ||ý!=0){return;}if(ÿ<=0){var Ě=new Random();var ě=Ě.Next(START_LIGHTS_OUT_TIME_MIN,
START_LIGHTS_OUT_TIME_MAX+1);var Ĝ=START_LIGHTS_COUNT*TIME_PER_LIGHT;ÿ=START_LIGHTS_STARTUP_TIME+Ĝ+ě;ø=ÿ;for(int Q=0;Q<ì.Count;Q++){Ç(Q,false);}
foreach(var Ê in í){Ê.Enabled=true;Ê.Color=Color.Black;}Û("Starting Countdown...\n");return;}ÿ-=(int)(Runtime.TimeSinceLastRun.
TotalMilliseconds);if(ÿ>ø-START_LIGHTS_STARTUP_TIME){return;}for(int Q=0;Q<START_LIGHTS_COUNT;Q++){Ç(Q,ÿ<=ø-START_LIGHTS_STARTUP_TIME-((Q
+1)*TIME_PER_LIGHT));}if(ÿ<=0){õ=false;for(int Q=0;Q<ì.Count;Q++){Ç(Q,false);}foreach(var Ê in í){Ê.Enabled=true;Ê.Color=
Color.Lime;}ý=DateTime.Now.Ticks;Û($"Race started after {ø} milliseconds!\n");}}void Ā(){ï.Clear();è.DetectedEntities(ï);var
ā=DateTime.Now.Ticks;foreach(var K in ï){if(K.IsEmpty()){continue;}if(K.Name.Contains("Grid")){continue;}if(î.ContainsKey
(K.Name)){var A=î[K.Name];if(ô==ú.û&&A.Đ>=RACE_LAPS){continue;}if(A.ď.Any(Þ=>Þ==false)){continue;}var Z=new TimeSpan((ā-A
.č));A.Ď.Add(Z);A.č=ā;for(int Q=0;Q<A.ď.Length;Q++){A.ď[Q]=false;}var a=$"{A.Ċ} set a lap!"+(ô==ú.û?
$"({A.Đ}/{RACE_LAPS})\n":"\n");Û(a);N();}else{long Ă;var ă=ñ.TryGetValue(K.Name,out Ă);î[K.Name]=new ĉ{Ċ=K.Name,Č=ă?Ă:(long?)null,č=ô==ú.û?ý:ā,}
;if(ă){ñ.Remove(K.Name);}Û($"{K.Name} registered!\n");}n();W();J(K);}}void Ą(){for(int Q=0;Q<é.Count;Q++){ï.Clear();var ą
=é[Q];ą.DetectedEntities(ï);foreach(var K in ï){if(K.IsEmpty()){continue;}if(K.Name.Contains("Grid")){continue;}if(î.
ContainsKey(K.Name)){var A=î[K.Name];A.ď[Q]=true;}}}}void Ć(){if(ë==null){return;}ï.Clear();ë.DetectedEntities(ï);foreach(var K in
ï){if(K.IsEmpty()){continue;}if(K.Name.Contains("Grid")){continue;}if(î.ContainsKey(K.Name)){var A=î[K.Name];if(A.Č.
HasValue){IGC.SendUnicastMessage(A.Č.Value,"Argument","LMT_ON");}}}}void ć(){if(ö==null){return;}ï.Clear();ö.DetectedEntities(ï)
;var ā=DateTime.Now.Ticks;foreach(var K in ï){if(K.IsEmpty()){continue;}if(K.Name.Contains("Grid")){continue;}if(!î.
ContainsKey(K.Name)){continue;}var A=î[K.Name];if(A.Č.HasValue){IGC.SendUnicastMessage(A.Č.Value,"Argument","LMT_OFF");}if(ô==ú.û&&
A.Đ>=RACE_LAPS){continue;}if(A.ď.Any(Þ=>Þ==false)){continue;}var Z=new TimeSpan((ā-A.č));A.Ď.Add(Z);A.č=ā;for(int Q=0;Q<A
.ď.Length;Q++){A.ď[Q]=false;}var a=$"{A.Ċ} set a lap!"+(ô==ú.û?$"({A.Đ}/{RACE_LAPS})\n":"\n");Û(a);N();}}void b(){ð.Clear
();ð.AppendLine($"- Position -");ð.AppendLine();for(int d=0;d<ò.Count;d++){var R=d+1;var A=ò[d];A.ċ=R;var S=x(A.Ċ.Trim(),
15).Trim();var e=A.Ĕ;var f=$"{e.Minutes:00}:{e.Seconds:00}.{e.Milliseconds:000}";var V=À($"#{R:00}> {S}",
$"L{A.Đ:00} ({f})");ð.AppendLine(V);}ã.WriteText(ð);}void g(){if(ä==null){return;}var h=î.Values.OrderBy(P=>P.Ċ).ToList();ð.Clear();ð.
AppendLine("- Laps Logs -");ð.AppendLine();for(int Q=0;Q<h.Count;Q++){var A=h[Q];for(int k=0;k<A.Ď.Count;k++){var m=k+1;var S=x(A.
Ċ.Trim(),20).Trim();var Z=A.Ď[k];var f=$"{Z.Minutes:00}:{Z.Seconds:00}.{Z.Milliseconds:000}";var V=À($"{S}",
$"L{m:00} ({f})");ð.AppendLine(V);}}ä.WriteText(ð);}void n(){ò=î.Values.OrderByDescending(P=>P.Đ).ThenBy(P=>P.Ĕ).ToList();}void q(){
foreach(var Y in î.Keys){var A=î[Y];if(!A.Č.HasValue){continue;}var L="RaceData";var B=A.đ;var C=
$"{B.Minutes:00}:{B.Seconds:00}.{B.Milliseconds:000}";var D=A.ē;var E=$"{D.Minutes:00}:{D.Seconds:00}.{D.Milliseconds:000}";var F=$"{î.Count}";var G=$"{RACE_LAPS}";var H=
$"{(int)ó}";var I=$"{A.Đ};{A.ċ};{C};{E};{F};{G};{H}";IGC.SendUnicastMessage(A.Č.Value,L,I);}}void J(MyDetectedEntityInfo K){if(å==
null){return;}var M=K.Velocity;var X=Math.Sqrt(M.X*M.X+M.Y*M.Y+M.Z*M.Z);å.WriteText("Speed:\n"+X.ToString("F2")+"\nm/s");}
void N(){if(æ==null){return;}ð.Clear();ð.AppendLine("- Fastest Laps -");ð.AppendLine();var O=î.Values.OrderBy(P=>P.ē).ToList
();for(int Q=0;Q<O.Count;Q++){var R=Q+1;var S=x(O[Q].Ċ.Trim(),20).Trim();var T=O[Q].ē;var U=
$"{T.Minutes:00}:{T.Seconds:00}.{T.Milliseconds:000}";var V=À($"#{R:00}> {S}",U);ð.AppendLine(V);}æ.WriteText(ð);}void W(){if(ç.Count<=0){return;}var o=î.Values.
OrderByDescending(P=>P.Đ).Select(P=>P.Đ).FirstOrDefault();ð.Clear();ð.AppendLine(o.ToString());foreach(var Ë in ç){Ë.WriteText(ð);}}void
Ì(){ã=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(MAIN_LCD_NAME);if(ã==null){throw new Exception(
$"\'{MAIN_LCD_NAME}\' not set!");}else{ã.ContentType=ContentType.TEXT_AND_IMAGE;ã.Alignment=TextAlignment.CENTER;ã.Font="Monospace";ã.FontSize=0.67f;}ä
=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(LAPS_LCD_NAME);if(ä!=null){ä.ContentType=ContentType.TEXT_AND_IMAGE;ä.
Alignment=TextAlignment.CENTER;ä.Font="Monospace";ä.FontSize=0.67f;}å=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(
SPEEDTRAP_LCD_NAME);if(å!=null)å.ContentType=ContentType.TEXT_AND_IMAGE;æ=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(
FASTEST_LAPS_LCD_NAME);if(æ!=null){æ.ContentType=ContentType.TEXT_AND_IMAGE;æ.Alignment=TextAlignment.CENTER;æ.Font="Monospace";æ.FontSize=
0.67f;}ç=new List<IMyTextPanel>();var Í=GridTerminalSystem.GetBlockGroupWithName(LAP_COUNTERS_GROUP_NAME);if(Í!=null){Í.
GetBlocksOfType(ç);foreach(var Ë in ç){Ë.ContentType=ContentType.TEXT_AND_IMAGE;Ë.Alignment=TextAlignment.CENTER;Ë.FontSize=10f;Ë.
TextPadding=17f;}}}void Î(){è=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(START_FINISH_SENSOR_NAME);if(è==null){throw new
Exception($"\'{START_FINISH_SENSOR_NAME}\' not set!");}if(CHECKPOINT_COUNT<1){throw new Exception(
$"The grid must have at least one checkpoint sensor.");}for(int Q=1;Q<=CHECKPOINT_COUNT;Q++){var Ï=CHECKPOINT_SENSOR_PREFIX+Q;var Ð=(IMySensorBlock)GridTerminalSystem.
GetBlockWithName(Ï);if(Ð==null){throw new Exception($"\'{Ï}\' not set!");}é.Add(Ð);}ë=(IMySensorBlock)GridTerminalSystem.
GetBlockWithName(PIT_ENTRY_SENSOR_NAME);ö=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(PIT_EXIT_SENSOR_NAME);}void Ñ(){if(
START_LIGHTS_COUNT<3){throw new Exception($"The grid must have at least 3 start lights.");}for(int Q=1;Q<=START_LIGHTS_COUNT;Q++){var Ò=
START_LIGHTS_PREFIX+Q;var Ó=GridTerminalSystem.GetBlockGroupWithName(Ò);if(Ó==null){throw new Exception($"\'{Ò}\' not set!");}var Ô=new
List<IMyLightingBlock>();Ó.GetBlocksOfType(Ô);ì.Add(Ô);}var Õ=new List<IMyLightingBlock>();var Ö=GridTerminalSystem.
GetBlockGroupWithName(START_LIGHTS_GO);if(Ö!=null){Ö.GetBlocksOfType(Õ);}í=Õ;}void Ø(){var Ù=Me.GetSurface(0);Ù.ContentType=ContentType.
TEXT_AND_IMAGE;Ù.ClearImagesFromSelection();Ù.Alignment=TextAlignment.LEFT;Ù.Font="Monospace";Ù.FontColor=Color.Lime;Ù.BackgroundColor
=Color.Black;Ù.FontSize=0.75f;Ù.TextPadding=2;Ù.WriteText("",false);}void Ú(){î.Clear();õ=false;ý=0;ø=0;ÿ=0;ò.Clear();ó=ù
.ß;for(int Q=0;Q<ì.Count;Q++){Ç(Q,false);}ã.WriteText("",false);if(ä!=null)ä.WriteText("",false);if(æ!=null)æ.WriteText(
"",false);if(å!=null)å.WriteText("",false);if(ç!=null&&ç.Count>0){foreach(var Ë in ç){Ë.WriteText("0",false);}}Me.
GetSurface(0).WriteText("",false);}void Û(string Ü){Echo(Ü);Ý(Ü);}void Ý(string Ü){Me.GetSurface(0).WriteText(Ü,true);}string À(
string Y,object s){return À(Y,s.ToString());}string À(string Y,string s,int u=999){var w=MathHelper.Clamp(DISPLAY_WIDTH-s.
Length-2,0,u);return Y.PadRight(w,'.')+": "+s;}string x(string y,int z){if(z<y.Length){return y.Substring(0,z);}return y;}void
ª(){Ĉ-=(int)Runtime.TimeSinceLastRun.TotalMilliseconds;if(Ĉ<=0){IGC.SendBroadcastMessage("Address",IGC.Me.ToString());Ĉ=
BROADCAST_COOLDOWN;}}void µ(){var º=IGC.UnicastListener;while(º.HasPendingMessage){var Á=º.AcceptMessage();switch(Á.Tag){case"Register":É(
Á);break;case"Flag":Å(Á);break;default:break;}}}void É(MyIGCMessage Á){var Â=Á.Data.ToString().Split(';');if(Â.Length<2){
return;}var Ã=Â[0];var Ä=Convert.ToInt64(Â[1]);if(î.ContainsKey(Ã)){î[Ã].Č=Ä;return;}if(ñ.ContainsKey(Ã)){ñ[Ã]=Ä;return;}ñ.Add
(Ã,Ä);}void Å(MyIGCMessage Á){var Æ=(ù)Convert.ToInt32(Á.Data);ó=Æ;}void Ç(int È,bool s){var Ô=ì[È];foreach(var Ê in Ô){Ê
.Enabled=true;Ê.Color=s?Color.Red:Color.Black;}}