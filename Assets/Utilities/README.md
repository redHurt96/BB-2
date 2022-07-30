# Utilities

* Singleton base classes - Singleton<T> / MonobehaviourSingleton<T>
* ResourcesLoader - враппер на загрузку из ресурсов с проверкой загруженных в память объектов
* PlayModeLogs - панель с игровыми логами
* SceneManagement - загрузчик сцен с поддержкой выполнения процессов до и после запуска сцены и предоставлением точки входа при окончании смены сцен
* Processes - последовательное / параллельное выполнение синхронных / асинхронных процессов
* Coroutines - запуск корутин не из MonoBehaviour
* StateMachine
* ReadOnlyAttribute - сериализованная Unity поле показано в инспекторе, но закрыто для редактирования. Найдено [здесь](https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html)

## Как установить утилиты сабмодулем к другому репозиторию
  1. Открыть репозиторий, в который нужно импортировать утилиты, в командной строке.
  2. Перейти в папку Assets с помощью команды `cd Assets`
  3. Добавить командой `git submodule add https://github.com/redHurt96/Utilities.git`
  
