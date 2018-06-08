//游戏状态
public class GameState {
	public static bool ScenceFinish=false;//关卡是否完成

	public static bool ScenceLock = true;//关卡是否解锁

	public static bool GameBegin=false;

	public static bool GameStop=false;//游戏是否暂停

	public static bool JumpPage=false;//是否正在跳转

	public static bool ButtonOneClicked=false;//是否单击按钮一

	public static bool ButtonTwoClicked=false;//是否单击按钮二

	public static bool ButtonThreeClicked=false;//是否单击按钮三

	public static bool ButtonFourClicked=false;//是否单击按钮四

	public static bool ButtonFiveClicked=false;//是否单击按钮五

	public static bool ToolSectionFinish = false;//是否完成部分工具

	public static bool ToolFinish=false;//工具是否全部完成

	public static ushort Timer=0;//计时器

	public static bool IsCustomsClearance=false;//游戏完全通关

	public static bool IsShowBackAD = true;//后台返回是否显示广告

	public static void GameIniteFalse(){
		ScenceFinish=false;//关卡是否完成

		ScenceLock = false;//关卡是否解锁

		GameBegin = false;

		GameStop=false;//游戏是否暂停

		JumpPage=false;//是否正在跳转

		ButtonOneClicked=false;//是否单击按钮一

		ButtonTwoClicked=false;//是否单击按钮二

		ButtonThreeClicked=false;//是否单击按钮三

		ButtonFourClicked=false;//是否单击按钮四

		ButtonFiveClicked=false;//是否单击按钮五

		ToolSectionFinish = false;

		ToolFinish = false;

		Timer = 0;

		IsCustomsClearance=false;

		IsShowBackAD = true;

	}

}
