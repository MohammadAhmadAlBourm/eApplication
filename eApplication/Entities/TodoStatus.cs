namespace eApplication.Entities;

public enum TodoStatus
{
    NotStarted = 1,  // Task has not yet been started
    InProgress = 2,  // Task is currently being worked on
    Completed = 3,   // Task has been completed
    OnHold = 4,      // Task is on hold or paused
    Canceled = 5,    // Task has been canceled and will not be completed
    Overdue = 6      // Task is past its due date and is not completed
}