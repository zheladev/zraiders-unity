public interface IObservable<T>
{
    void Attach(IObserver<T> observer);
    void Detach(IObserver<T> observer);
    void Notify(T payload);
}
