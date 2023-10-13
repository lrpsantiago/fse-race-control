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
private const int INITIAL_RISK_OF_RAIN = 50;
private const int WEATHER_CHANGE_TIME = 10000;
private const int RAIN_TIME_MIN = 60000 * 5;
private const int RAIN_TIME_MAX = 60000 * 25;

enum ċ{Č,č,ď}enum Ď{Ċ,Ĉ,ì,í}enum î{ï,ð}string ñ="11.0.0";IMyTextPanel ò;IMyTextPanel ó;IMyTextPanel ô;IMyTextPanel õ;
List<IMyTextPanel>ö;IMySensorBlock ø;IList<IMySensorBlock>ù=new List<IMySensorBlock>();IMySensorBlock ú;IMySensorBlock û;
IList<IEnumerable<IMyLightingBlock>>ü=new List<IEnumerable<IMyLightingBlock>>();IEnumerable<IMyLightingBlock>ý;Dictionary<
string,į>þ=new Dictionary<string,į>();List<MyDetectedEntityInfo>ÿ=new List<MyDetectedEntityInfo>();StringBuilder Ā;Dictionary<
string,long>ā;List<į>Ă=new List<į>();Ď ă=Ď.Ċ;î Ą=î.ï;int ą=INITIAL_RISK_OF_RAIN;string Ć;int ć=-1;ċ ë;bool Đ;long đ;int Ġ;int
ġ;int Ģ;class ģ{private long Ĥ;private long?ĥ;private long[]Ħ;public TimeSpan ħ{get{if(ĥ!=null){return new TimeSpan(ĥ.
Value-Ĥ);}return new TimeSpan(DateTime.Now.Ticks-Ĥ);}}public bool Ĩ{get{return Ħ.All(ĩ=>ĩ>0);}}public bool Ī{get{return ĥ!=
null;}}public ģ(long ī){Ĥ=ī;ĥ=null;Ħ=new long[CHECKPOINT_COUNT];for(int h=0;h<Ħ.Length;h++){Ħ[h]=-1;}}public void Ĭ(int h){Ħ
[h]=DateTime.Now.Ticks;}public void ĭ(){ĥ=DateTime.Now.Ticks;}public override string ToString(){var Į=ħ;return
$"{Į.Minutes:00}:{Į.Seconds:00}.{Į.Milliseconds:000}";}}class į{public string İ{get;set;}public int ı{get;set;}public long?Ĳ{get;set;}public IList<ģ>ĳ{get;set;}=new List<ģ>(
);public int Ĵ{get{return ĳ.Count;}}public ģ ĵ{get{return ĳ.LastOrDefault();}}public TimeSpan Ķ{get{return ĵ!=null?ĵ.ħ:
TimeSpan.Zero;}}public TimeSpan?ķ{get{return ĳ.Count>1?ĳ.Last(Ô=>Ô.Ī).ħ:(TimeSpan?)null;}}public TimeSpan?Ĺ{get{var ĸ=ĳ.Where(Ô
=>Ô.Ī);return ĸ.Count()>0?ĸ.Min(Ô=>Ô.ħ):(TimeSpan?)null;}}public TimeSpan Ē{get{var ē=ĳ.Where(Ô=>Ô.Ī).Sum(Ĕ=>Ĕ.ħ.Ticks);
return new TimeSpan(ē);}}}Program(){ā=new Dictionary<string,long>();Ā=new StringBuilder();Runtime.UpdateFrequency=
UpdateFrequency.Update1;try{æ();é("Initializing Race Script...\n");é("Detecting LCDs.................");Ü();é("OK!\n");é(
"Detecting Sensors..............");Þ();é("OK!\n");é("Detecting Start Lights.........");á();é("OK!\n");ė("FREE");é("Waiting for players...\n");}catch(
Exception e){é("\nError: "+e.Message);}Y();}void Save(){}void Main(string ĕ,UpdateType Ė){Echo($"Running FSE Race Control {ñ}+");
ė(ĕ);Ç();È();Ę();Ĝ();g();m();n();s();y();Û();E();}void ė(string ĕ){switch(ĕ){case"RACE":è();Đ=true;ë=ċ.Č;Ó("Race Mode!\n"
);break;case"QUALI":è();ë=ċ.č;Ó("Quilifying Mode!\n");break;case"FREE":è();ë=ċ.ď;Ó("Free Practice Mode!\n");break;case
"FLAG_G":ă=Ď.Ċ;break;case"FLAG_Y":ă=Ď.Ĉ;break;case"FLAG_R":ă=Ď.ì;break;default:break;}}void Ę(){if(!Đ||đ!=0){return;}if(ġ<=0){
var ę=new Random();var Ě=ę.Next(START_LIGHTS_OUT_TIME_MIN,START_LIGHTS_OUT_TIME_MAX+1);var ě=START_LIGHTS_COUNT*
TIME_PER_LIGHT;ġ=START_LIGHTS_STARTUP_TIME+ě+Ě;Ġ=ġ;for(int h=0;h<ü.Count;h++){Ñ(h,false);}foreach(var Ô in ý){Ô.Enabled=true;Ô.Color=
Color.Black;}é("Starting Countdown...\n");return;}ġ-=(int)(Runtime.TimeSinceLastRun.TotalMilliseconds);if(ġ>Ġ-
START_LIGHTS_STARTUP_TIME){return;}for(int h=0;h<START_LIGHTS_COUNT;h++){Ñ(h,ġ<=Ġ-START_LIGHTS_STARTUP_TIME-((h+1)*TIME_PER_LIGHT));}if(ġ<=0){Đ=
false;for(int h=0;h<ü.Count;h++){Ñ(h,false);}foreach(var Ô in ý){Ô.Enabled=true;Ô.Color=Color.Lime;}đ=DateTime.Now.Ticks;é(
$"Race started after {Ġ} milliseconds!\n");}}void Ĝ(){ÿ.Clear();ø.DetectedEntities(ÿ);var o=DateTime.Now.Ticks;var ĝ=new Random();foreach(var V in ÿ){if(V.
IsEmpty()){continue;}if(V.Name.Contains("Grid")){continue;}if(þ.ContainsKey(V.Name)){var G=þ[V.Name];if(ë==ċ.Č&&G.Ĵ>=RACE_LAPS)
{continue;}if(!G.ĵ.Ĩ){continue;}G.ĵ.ĭ();var a=new ģ(o);G.ĳ.Add(a);Y();}else{long Ğ;var ğ=ā.TryGetValue(V.Name,out Ğ);var
ĉ=new į{İ=V.Name,Ĳ=ğ?Ğ:(long?)null,};var ê=ë==ċ.Č?đ:o;var b=new ģ(ê);ĉ.ĳ.Add(b);þ[V.Name]=ĉ;if(ğ){ā.Remove(V.Name);}é(
$"{V.Name} registered!\n");}D();Ø();U(V);if(ë==ċ.Č){var f=Ă.FirstOrDefault();if(f!=null&&f==þ[V.Name]&&ą<100){ą+=ĝ.Next(-4,9);ą=MathHelper.Clamp(
ą,0,100);Ó($"RoR: {ą}\n");if(ą==100&&ć<=0){ć=WEATHER_CHANGE_TIME;}}}}}void g(){for(int h=0;h<ù.Count;h++){ÿ.Clear();var k
=ù[h];k.DetectedEntities(ÿ);foreach(var V in ÿ){if(V.IsEmpty()){continue;}if(V.Name.Contains("Grid")){continue;}if(þ.
ContainsKey(V.Name)){var G=þ[V.Name];G.ĵ.Ĭ(h);}}}D();}void m(){if(ú==null){return;}ÿ.Clear();ú.DetectedEntities(ÿ);foreach(var V in
ÿ){if(V.IsEmpty()){continue;}if(V.Name.Contains("Grid")){continue;}if(þ.ContainsKey(V.Name)){var G=þ[V.Name];if(G.Ĳ.
HasValue){IGC.SendUnicastMessage(G.Ĳ.Value,"Argument","LMT_ON");}}}}void n(){if(û==null){return;}ÿ.Clear();û.DetectedEntities(ÿ)
;var o=DateTime.Now.Ticks;foreach(var V in ÿ){if(V.IsEmpty()){continue;}if(V.Name.Contains("Grid")){continue;}if(!þ.
ContainsKey(V.Name)){continue;}var G=þ[V.Name];if(G.Ĳ.HasValue){IGC.SendUnicastMessage(G.Ĳ.Value,"Argument","LMT_OFF");}if(ë==ċ.Č&&
G.Ĵ>=RACE_LAPS){continue;}if(!G.ĵ.Ĩ){continue;}G.ĵ.ĭ();var q=new ģ(o);G.ĳ.Add(q);Y();}}void s(){Ā.Clear();Ā.AppendLine(
$"- Position -");Ā.AppendLine();for(int u=0;u<Ă.Count;u++){var w=u+1;var G=Ă[u];G.ı=w;var d=Ä(G.İ.Trim(),15).Trim();var x=G.Ē;var B=
$"{x.Minutes:00}:{x.Seconds:00}.{x.Milliseconds:000}";var C=À($"#{w:00}> {d}",$"L{G.Ĵ:00} ({B})");Ā.AppendLine(C);}Ć=Ā.Replace(';',' ').ToString();ò.WriteText(Ć);}void y(){
if(ó==null){return;}var z=þ.Values.OrderBy(A=>A.İ).ToList();Ā.Clear();Ā.AppendLine("- Laps Logs -");Ā.AppendLine();for(int
h=0;h<z.Count;h++){var G=z[h];for(int µ=0;µ<G.ĳ.Count;µ++){var ª=µ+1;var d=Ä(G.İ.Trim(),20).Trim();var a=G.ĳ[µ].ħ;var B=
$"{a.Minutes:00}:{a.Seconds:00}.{a.Milliseconds:000}";var C=À($"{d}",$"L{ª:00} ({B})");Ā.AppendLine(C);}}ó.WriteText(Ā);}void D(){Ă=þ.Values.OrderByDescending(A=>A.Ĵ).ThenBy
(A=>A.Ē).ToList();}void E(){foreach(var F in þ.Keys){var G=þ[F];if(!G.Ĳ.HasValue){continue;}var H="RaceData";var I=G.Ķ;
var J=$"{I.Minutes:00}:{I.Seconds:00}.{I.Milliseconds:000}";var K=G.Ĺ.GetValueOrDefault();var L=
$"{K.Minutes:00}:{K.Seconds:00}.{K.Milliseconds:000}";var M=$"{þ.Count}";var N=$"{RACE_LAPS}";var O=$"{(int)ă}";var P=$"{(int)Ą}";var Q=$"{ą}";var R=
$"{Math.Ceiling((float)ć/1000)}";var S=Ć;var T=$"{G.Ĵ};{G.ı};{J};{L};{M};{N};{O};{P};{Q};{R};{S}";IGC.SendUnicastMessage(G.Ĳ.Value,H,T);}}void U(
MyDetectedEntityInfo V){if(ô==null){return;}var W=V.Velocity;var X=Math.Sqrt(W.X*W.X+W.Y*W.Y+W.Z*W.Z);ô.WriteText("Speed:\n"+X.ToString("F2"
)+"\nm/s");}void Y(){if(õ==null){return;}Ā.Clear();Ā.AppendLine("- Fastest Laps -");Ā.AppendLine();var Z=þ.Values.OrderBy
(A=>A.Ĺ).ToList();for(int h=0;h<Z.Count;h++){var w=h+1;var d=Ä(Z[h].İ.Trim(),20).Trim();var Õ=Z[h].Ĺ.GetValueOrDefault();
var Ö=Z[h].Ĺ.HasValue?$"{Õ.Minutes:00}:{Õ.Seconds:00}.{Õ.Milliseconds:000}":"00:00.000";var C=À($"#{w:00}> {d}",Ö);Ā.
AppendLine(C);}õ.WriteText(Ā);}void Ø(){if(ö.Count<=0){return;}var Ù=þ.Values.OrderByDescending(A=>A.Ĵ).Select(A=>A.Ĵ).
FirstOrDefault();Ā.Clear();Ā.AppendLine(Ù.ToString());foreach(var Ú in ö){Ú.WriteText(Ā);}}void Û(){if(ć<=0||ë!=ċ.Č){return;}ć-=(int)
Runtime.TimeSinceLastRun.TotalMilliseconds;if(ć<=0){Ą=î.ð;}}void Ü(){ò=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(
MAIN_LCD_NAME);if(ò==null){throw new Exception($"\'{MAIN_LCD_NAME}\' not set!");}else{ò.ContentType=ContentType.TEXT_AND_IMAGE;ò.
Alignment=TextAlignment.CENTER;ò.Font="Monospace";ò.FontSize=0.67f;}ó=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(
LAPS_LCD_NAME);if(ó!=null){ó.ContentType=ContentType.TEXT_AND_IMAGE;ó.Alignment=TextAlignment.CENTER;ó.Font="Monospace";ó.FontSize=
0.67f;}ô=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(SPEEDTRAP_LCD_NAME);if(ô!=null)ô.ContentType=ContentType.
TEXT_AND_IMAGE;õ=(IMyTextPanel)GridTerminalSystem.GetBlockWithName(FASTEST_LAPS_LCD_NAME);if(õ!=null){õ.ContentType=ContentType.
TEXT_AND_IMAGE;õ.Alignment=TextAlignment.CENTER;õ.Font="Monospace";õ.FontSize=0.67f;}ö=new List<IMyTextPanel>();var Ý=
GridTerminalSystem.GetBlockGroupWithName(LAP_COUNTERS_GROUP_NAME);if(Ý!=null){Ý.GetBlocksOfType(ö);foreach(var Ú in ö){Ú.ContentType=
ContentType.TEXT_AND_IMAGE;Ú.Alignment=TextAlignment.CENTER;Ú.FontSize=10f;Ú.TextPadding=17f;}}}void Þ(){ø=(IMySensorBlock)
GridTerminalSystem.GetBlockWithName(START_FINISH_SENSOR_NAME);if(ø==null){throw new Exception($"\'{START_FINISH_SENSOR_NAME}\' not set!");
}if(CHECKPOINT_COUNT<1){throw new Exception($"The grid must have at least one checkpoint sensor.");}for(int h=1;h<=
CHECKPOINT_COUNT;h++){var ß=CHECKPOINT_SENSOR_PREFIX+h;var à=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(ß);if(à==null){throw
new Exception($"\'{ß}\' not set!");}ù.Add(à);}ú=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(PIT_ENTRY_SENSOR_NAME);
û=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(PIT_EXIT_SENSOR_NAME);}void á(){if(START_LIGHTS_COUNT<3){throw new
Exception($"The grid must have at least 3 start lights.");}for(int h=1;h<=START_LIGHTS_COUNT;h++){var â=START_LIGHTS_PREFIX+h;var
ã=GridTerminalSystem.GetBlockGroupWithName(â);if(ã==null){throw new Exception($"\'{â}\' not set!");}var e=new List<
IMyLightingBlock>();ã.GetBlocksOfType(e);ü.Add(e);}var ä=new List<IMyLightingBlock>();var å=GridTerminalSystem.GetBlockGroupWithName(
START_LIGHTS_GO);if(å!=null){å.GetBlocksOfType(ä);}ý=ä;}void æ(){var ç=Me.GetSurface(0);ç.ContentType=ContentType.TEXT_AND_IMAGE;ç.
ClearImagesFromSelection();ç.Alignment=TextAlignment.LEFT;ç.Font="Monospace";ç.FontColor=Color.Lime;ç.BackgroundColor=Color.Black;ç.FontSize=
0.75f;ç.TextPadding=2;ç.WriteText("",false);}void è(){þ.Clear();Đ=false;đ=0;Ġ=0;ġ=0;Ă.Clear();ă=Ď.Ċ;Ą=î.ï;ą=
INITIAL_RISK_OF_RAIN;ć=-1;for(int h=0;h<ü.Count;h++){Ñ(h,false);}ò.WriteText("",false);if(ó!=null)ó.WriteText("",false);if(õ!=null)õ.
WriteText("",false);if(ô!=null)ô.WriteText("",false);if(ö!=null&&ö.Count>0){foreach(var Ú in ö){Ú.WriteText("0",false);}}Me.
GetSurface(0).WriteText("",false);}void é(string º){Echo(º);Ó(º);}void Ó(string º){Me.GetSurface(0).WriteText(º,true);}string À(
string F,object Á){return À(F,Á.ToString());}string À(string F,string Á,int Â=999){var Ã=MathHelper.Clamp(DISPLAY_WIDTH-Á.
Length-2,0,Â);return F.PadRight(Ã,'.')+": "+Á;}string Ä(string Å,int Æ){if(Æ<Å.Length){return Å.Substring(0,Æ);}return Å;}void
Ç(){Ģ-=(int)Runtime.TimeSinceLastRun.TotalMilliseconds;if(Ģ<=0){IGC.SendBroadcastMessage("Address",IGC.Me.ToString());Ģ=
BROADCAST_COOLDOWN;}}void È(){var É=IGC.UnicastListener;while(É.HasPendingMessage){var Ê=É.AcceptMessage();switch(Ê.Tag){case"Register":Ë(
Ê);break;case"Flag":Ï(Ê);break;default:break;}}}void Ë(MyIGCMessage Ê){var Ì=Ê.Data.ToString().Split(';');if(Ì.Length<2){
return;}var Í=Ì[0];var Î=Convert.ToInt64(Ì[1]);if(þ.ContainsKey(Í)){þ[Í].Ĳ=Î;return;}if(ā.ContainsKey(Í)){ā[Í]=Î;return;}ā.Add
(Í,Î);}void Ï(MyIGCMessage Ê){var Ð=(Ď)Convert.ToInt32(Ê.Data);ă=Ð;}void Ñ(int Ò,bool Á){var e=ü[Ò];foreach(var Ô in e){Ô
.Enabled=true;Ô.Color=Á?Color.Red:Color.Black;}}