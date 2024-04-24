public class Object_Medication : InteractableObject
{
    public override void InteractWithObject()
    {
        PlayerSanity.sanity += 5f;
    }
}
