using System.Diagnostics.SymbolStore;
using Godot;
namespace Touch;
[GlobalClass()]
public partial class TouchButton : TouchPad
{
    [Export] public Panel Pan = null;
    [Export] public StyleBoxTexture Down_Texture;
    [Export] public StyleBoxTexture Normal_Texture;
    [Export] public StyleBoxTexture Focus_Texture;
    public override void _Ready() {
        base._Ready();
        Button_Downvoid += Down;
        Button_UPvoid += UP;
        Focus_Joinvoid += focus;
        Focus_Exitvoid += Exit_Focus;
    }
    public void Down()
    {
        if (!(Down_Texture is null))
        {
            Pan.AddThemeStyleboxOverride("panel",Down_Texture);
        }
    }
    public void UP(){
        if (!(Normal_Texture is null))
        {
            Pan.AddThemeStyleboxOverride("panel",Normal_Texture);
        }
    }
    public void focus()
    {
        if (!(Focus_Texture is null))
        {
            Pan.AddThemeStyleboxOverride("panel",Focus_Texture);
        }
    }
    public void Exit_Focus()
    {
        if(Pressed){return;}
        if (!(Normal_Texture is null))
        {
            Pan.AddThemeStyleboxOverride("panel",Normal_Texture);
        }
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if(Pan is null)
        {
            Pan = new();
            AddChild(Pan);
            Pan.AddThemeStyleboxOverride("panel",Normal_Texture);
        }
        else
        {
            Pan.Position = new Vector2(0,0);
            Pan.Size = Size;
        }
    }

}
