namespace Global.Inputs.View.Logs
{
    public enum InputViewLogType
    {
        MovementPressed,
        MovementCanceled,

        RangeAttackPerformed,
        RangeAttackCanceled,

        BeforeRebind,
        AfterRebind,

        ConstraintAdded,
        ConstraintReduced,
        ConstraintRemoved,
        ConstraintBelowZeroException,
        InputCanceledWithConstraint
    }
}