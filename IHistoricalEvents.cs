using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace _20180417_WCF_HistoricalEventsServiceLib
{
    [ServiceContract]
    public interface IHistoricalEvents
    {
        /// <summary>
        /// Проверка соединения.
        /// </summary>
        /// <returns>OK</returns>
        [OperationContract]
        string TestConnection();

        /// <summary>
        /// Метод InfoAboutEvents() выводит информацию об исторических событиях.
        /// </summary>
        /// <param name="startDate">Дата начала поиска исторических событий.</param>
        /// <returns>Список исторических событий на протяжении недели начиная от стартовой даты.</returns>
        [OperationContract]
        List<CalendarOfEvents> InfoAboutEvents(DateTime startDate);
    }

    [DataContract]
    public class CalendarOfEvents
    {
        /// <summary>
        /// Дата события.
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Информация о событии.
        /// </summary>
        [DataMember]
        public string SomeEvent { get; set; }

        /// <summary>
        /// Конструктор класса CalendarOfEvents
        /// </summary>
        /// <param name="date">Дата события.</param>
        /// <param name="someEvent">Информация о событии.</param>
        public CalendarOfEvents(DateTime date, string someEvent)
        {
            Date = date;
            SomeEvent = someEvent;
        }

        /// <summary>
        /// Метод ToString() позволяет отображать информацию о событии в виде строки.
        /// </summary>
        /// <returns>Информация о событии в виде строки.</returns>
        public override string ToString()
        {
            return $"{Date:M} {SomeEvent}";
        }
    }
}