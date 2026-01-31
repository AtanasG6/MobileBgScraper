using AngleSharp;
using AngleSharp.Dom;
using System.Text;

namespace MobileBgScraper;

public class Program
{
    public static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var config = Configuration.Default.WithDefaultLoader();
        var address = "https://www.mobile.bg/obiava-21760280914263432-opel-crossland-x-turbo-elegance";
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(address);

        var titleSelector = "body > div.ad2023 > div.right > div > div > div.obTitle > h1";
        var titleElement = document.QuerySelector(titleSelector);

        var adNumberSelector = "body > div.ad2023 > div.right > div > div > div.obTitle > h1 > div";
        var adNumber = document.QuerySelector(adNumberSelector);

        titleElement!.RemoveElement(adNumber);
        var title = titleElement.TextContent.TrimStart();

        Console.WriteLine($"Обява: {title}");

        var locationSelector = "body > div.ad2023 > div.right > div > div > div.carLocation > span";
        var locationElement = document.QuerySelector(locationSelector);
        var location = locationElement.TextContent;

        Console.WriteLine(location);

        var pricesSelector = "body > div.ad2023 > div.right > div > div > div.Price";
        var pricesElement = document.QuerySelector(pricesSelector);
        var prices = pricesElement.TextContent.Trim();

        var euroPrice = prices.Split('€')[0];
        var bgnPrice = prices.Split('€')[1].Split("лв.")[0];

        Console.WriteLine($"Цена: {euroPrice}€/{bgnPrice}лв");

        var phoneNumberSelector = "body > div.ad2023 > div.right > div > div > div.phone";
        var phoneNumberElement = document.QuerySelector(phoneNumberSelector);
        var phoneNumber = phoneNumberElement.TextContent.TrimStart().Split(' ')[0].TrimEnd();

        Console.WriteLine($"Телефон на продавача: {phoneNumber}");

        var manufactureDateSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(1) > div:nth-child(2)";
        var manufactureDateElement = document.QuerySelector(manufactureDateSelector);
        var manufactureDate = manufactureDateElement.TextContent;

        Console.WriteLine($"Дата на производство: {manufactureDate}");

        var engineSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(2) > div:nth-child(2)";
        var engineElement = document.QuerySelector(engineSelector);
        var engine = engineElement.TextContent;

        Console.WriteLine($"Двигател: {engine}");

        var enginePowerSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(3) > div:nth-child(2)";
        var enginePowerElement = document.QuerySelector(enginePowerSelector);
        var enginePower = enginePowerElement.TextContent;

        Console.WriteLine($"Мощност: {enginePower}");

        var euroStandardSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(4) > div:nth-child(2)";
        var euroStandardElement = document.QuerySelector(euroStandardSelector);
        var euroStandard = euroStandardElement.TextContent;

        Console.WriteLine($"Мощност: {euroStandard}");

        var cubicVolumeSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(5) > div:nth-child(2)";
        var cubicVolumeElement = document.QuerySelector(cubicVolumeSelector);
        var cubicVolume = cubicVolumeElement.TextContent;

        Console.WriteLine($"Кубатура [куб.см]: {cubicVolume}");

        var gearboxSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(6) > div:nth-child(2)";
        var gearboxElement = document.QuerySelector(gearboxSelector);
        var gearbox = gearboxElement.TextContent;

        Console.WriteLine($"Скоростна кутия: {gearbox}");

        var categorySelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(7) > div:nth-child(2)";
        var categoryElement = document.QuerySelector(categorySelector);
        var category = categoryElement.TextContent;

        Console.WriteLine($"Категория: {category}");

        var mileageSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(8) > div:nth-child(2)";
        var mileageElement = document.QuerySelector(mileageSelector);
        var mileage = mileageElement.TextContent;

        Console.WriteLine($"Пробег [км]: {mileage}");

        var colorSelector = "body > div.ad2023 > div.left > div:nth-child(5) > div > div > div:nth-child(9) > div:nth-child(2)";
        var colorElement = document.QuerySelector(colorSelector);
        var color = colorElement.TextContent;

        Console.WriteLine($"Цвят: {color}");

    }
}
