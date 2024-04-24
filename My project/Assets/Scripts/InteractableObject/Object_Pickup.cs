public class Object_Pickup : InteractableObject
{

    private bool _pickedUp;
    void Update()
    {
        if (!_pickedUp) return;
    }
    public override void InteractWithObject()
    {

    }
}
