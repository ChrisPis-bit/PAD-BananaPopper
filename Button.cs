using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Button : SpriteGameObject
{
    public bool Pressed { get; protected set; }

    public Button(string assetName) : base(assetName)
    {
        Pressed = false;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        Pressed = Visible && inputHelper.MouseLeftButtonPressed()
            && BoundingBox.Contains(inputHelper.MousePositionWorld);
    }

    public override void Reset()
    {
        base.Reset();
        Pressed = false;
    }
}