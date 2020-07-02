# Notissimus
Test task for Notissimus LLC
Добрый день! Это готовое тестовое задание для ООО "Нотиссимус"

Задача "Написать код на с# в соответствии с заданием ниже: Загрузить из XML файла массив объектов offer. Файл доступен по URL: http://partner.market.yandex.ru/pages/help/YML.xml

Создать таблицу базы данных SQL SERVER. Колонки таблицы должны соответствовать объекту offer. Записать данные в созданную таблицу, используя хранимую процедуру. Код решения разместить в репозитории github. Предоставить ссылку на репозиторий."

Для работы использовался SQLExpress

Алгоритм работы : 1) Для начала я дессериализовал полностью XML файл, взяв во внимание малую вложенность (Загрузил из XML файла в List<offers>. )
2) Затем, я конвертировал все в DataTable для дальнейшей передачи таблицы, как аргумента в хранимую процедуру.
3)Создал базу данных Offers с таблицей Offer, а так же создал пользовательскую таблицу [dbo].[OffersType], которая соответствовала структуре DataTable, чтобы передать туда значения DataTable
4)Создал хранимую процедуру 
  
ALTER PROCEDURE [dbo].[ImportOfferse]
@OffersTable OffersType ReadOnly
AS
BEGIN
		set	nocount on;

		insert INTO Offer (Url, Price, CurrencyId, CategoryId,
		Picture,Delivery,Local_delivery_cost,TypePrefix,Vendor,
		VendorCode, Model, Description, Manufacturer_warranty,
		Country_of_origin, Id, Type, Bid, Cbid, Available,
		Author, Name, Publisher, Series, Year, ISBN, Volume,
		Part, Language,Binding,[Page_extent], [Downloadable],
		[Performed_by],[Performance_type],[Storage],[Recording_length],[Artist],
		[Title],[Media],[Starring], [Director],[OriginalName],[Country],[WorldRegion],
		[Days],[DataTour],[Hotel_stars],[Room],[Included],[Transport],[Place],
		[Hall],[Is_premiere],[Is_kids], [Meal], [Region], [Hall_Part], [Date])

		Select [Url],[Price],CurrencyId, CategoryId, Picture,Delivery,Local_delivery_cost,TypePrefix,Vendor,
		VendorCode, Model, Description, Manufacturer_warranty,
		Country_of_origin, Id, Type, Bid, Cbid, Available,
		Author, Name, Publisher, Series, Year, ISBN, Volume,
		Part, Language,Binding,[Page_extent], [Downloadable],
		[Performed_by],[Performance_type],[Storage],[Recording_length],[Artist],
		[Title],[Media],[Starring], [Director],[OriginalName],[Country],[WorldRegion],
		[Days],[DataTour],[Hotel_stars],[Room],[Included],[Transport],[Place],
		[Hall],[Is_premiere],[Is_kids],[Meal],[Region],[Hall_Part],[Date] from @OffersTable

End

5)В конце загрузил в базу данных таблицу DataTable.

Получилось всё немного грубо, так как все поля класса Offer объявлены как string.

Спасибо что уделили время, изучая тестовое задание!
Хорошего дня :)
