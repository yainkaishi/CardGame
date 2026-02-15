// ゲーム内イベント情報
public class GameEvent
{
    public GameEventType EventType { get; private set; }
    public int SourcePlayerId { get; private set; }
    public int TargetPlayerId { get; private set; }
    public int Value { get; private set; }

    public GameEvent(GameEventType eventType, int sourcePlayerId, int targetPlayerId, int value = 0)
    {
        EventType = eventType;
        SourcePlayerId = sourcePlayerId;
        TargetPlayerId = targetPlayerId;
        Value = value;
    }
}
