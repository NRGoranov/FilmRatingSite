# FilmRatingSite
Здравейте,

Изпращам задачата за serverless приложение както се разбрахме.

Целта е да направите приложение, което е напълно serverless използвайки Azure Functions (Azure Function App) или Amazon Lambda Functions. За Azure би трябвало да може да ползвате безплатни кредити. За Amazon не съм сигурен, но предполагам също има вариант.

Приложението е много опростена система за оценка на филми и сериали, в която може да се създават записи, да се въвеждат мнения или оценки за тях и да се търси.

Идеята е приложението да може да направи следното:
1. Функция 1 с HTTP trigger да приема информация за филм: Заглавие, година, Жанр, Описание, Режисьор, Актьори. Достатъчно е да са просто стринг полета. Като се получи заявката се създава обект и се запазва в SQL база данни.
2. Функция 2 с HTTP trigger да приема информация за оценка за филм: Заглавие, Мнение, Рейтинг (от 1 до 10), Дата и час, Автор (име). Мненията се запазват в отделна таблица в базата данни, свързана с филмите.
3. Функция 3 с периодичен trigger да смята всеки ден в 11:30 часа средните стойности на оценките на всеки филм и да ги запазва в базата данни в една колона (напр. Average Rating).
4. Функция 4 с HTTP trigger да позволява на потребител да търси по име на филм и да връща резултатите - филмите с цялата информация за тях, заедно с оценките, пресметнатата средна оценка и мненията. Ако няма подаден search string - връща всички резултати.

Пишете ако имате въпроси или може да ги обсъдим в някой от часовете направо.


Когато сте готови изпратете линк към Github repo-то.
