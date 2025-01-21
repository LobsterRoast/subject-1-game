public abstract class ControllableEntity : Entity {
    private int active_accessory_count = 0;
    
    public Accessory active_accessory = Accessory.None;
    public Controllable controller;
    public bool ToggleAccessory(Accessory accessory) {
        if (active_accessory_count >= 2)
            return false;
        active_accessory ^= accessory;
        if ((active_accessory & accessory) > 0) 
            active_accessory_count++;
        else active_accessory_count--;
        return true;
    }
    public bool CheckAccessory(Accessory accessory) {
        return ((active_accessory & accessory) > 0);
    }
}