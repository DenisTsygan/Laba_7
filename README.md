# Laba_7
***Вариант 20***
#
Система комментариев (List):
Напишите систему для управления комментариями на веб-сайте. Пользователи должны иметь возможность добавлять и удалять комментарии.
# Laba_8
Реализовать сохранение и восстановление данных данных массивов объектов:<br/>
-_используя сохранение/восстановление в бинарном файле;_<br/>
-_используя сериализацию/десериализацию в JSON_;_<br/>
-_дополнительно оценивается реализация вышеуказанных операций при помощи отдельного универсального класса для реализации сохранения/восстановления данных, который принимает на вход сохраняемый список в виде объекта_.
# Laba_9
Реализовать в рамках как сортировки (по нескольким полям) так и фильтрации (по нескольким полям с возвратом отфильтрованной копии данных) данных:<br/><br/>
-_**Создание делегата**: Объявите делегат, подходящий для использования в Вашей задаче. Например, это может быть делегат для работы с функцией, принимающей и возвращающей значения определенного типа._<br/>
-_**Использование анонимных методов**: Реализуйте функциональность, используя анонимные методы. Анонимные методы позволяют создавать безымянные функции внутри метода._<br/>
-_**Использование лямбда-выражений**: Перепишите решение задачи, используя лямбда-выражения для более компактного и выразительного кода._<br/>
# Laba_10
1.Реализовать метод, который в 4 потока заполняет массив из 1 миллиона объектов случайными данными (обратите внимание на потенциальные проблемы многопоточности, такие как доступ к разделяемым ресурсам и попробуйте решить их, чтобы обеспечить корректную параллельную обработку). Общий размер массива и диапазон значений для каждого потока должны быть настраиваемыми параметрами (для возможности контроля корректности заполнения)</br>

2.Реализовать параллельную сортировку массива по выбранному полю (используйте многопоточность для разделения массива на подмассивы и их сортировки; в конечном итоге, объедините отсортированные подмассивы в один отсортированный массив)</br>

3.Создать несколько потоков (например, 4 или 8) и выполнить сортировки параллельно.</br>

4.Замерить время выполнения сортировки для разного количества потоков и сравнить полученные результаты с сортировкой без распараллеливания (сделайте выводы о производительности параллельной сортировки)</br>

5.Обеспечить корректную обработку исключений и учесть возможные ошибки</br>

**Результаты замерки времени**:</br>
Threads 5(paralel sort 100000 elements)=07.7749381 s;</br>
Threads 10(paralel sort 100000 elements)=02.4431662 s;</br>
Insertion sort 100000 elements =42.938223 s.</br>
Паралельная сортировка прекрасна показала себя против одноточной сортировки, следовательно при больших обьемах данных предпочтительно использовать паралельную сортировку и в зависимости от желаемых требований о производительности и возможности железа подбирать количевство потоков.
# Laba_11
-Реализовать простую фильтрацию (поиск) данных по всем полям.</br>
-Реализовать составную фильтрацию (с группировкой) по нескольким полям одновременно</br>
-Реализовать статистическую обработку данных. </br>

