using System;

public class SaveDataNotFoundException : Exception {
    public SaveDataNotFoundException() {}
    public SaveDataNotFoundException(string message) : base(message) {}
    public SaveDataNotFoundException(string message, Exception inner) : base(message, inner) {}
}