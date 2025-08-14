using System;
using System.Collections.Generic;

namespace Cybersecurity
{
    public class Option
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public int TimeHours { get; set; }
        public int Cost { get; set; }
        public List<string> Resources { get; set; }
        public string? Consequence { get; set; }

        public Option()
        {
            Resources = new List<string>();
        }
    }

    public class Step
    {
        public string Question { get; set; }
        public string Table { get; set; } // ЭТО НУЖНО СДЕЛАТЬ
        public List<Option> Options { get; set; }

        public Step()
        {
            Options = new List<Option>();
        }
    }

    public class Scenario
    {
        public int VariantId { get; set; }
        public string Incident { get; set; }
        public DateTime StartTime { get; set; }
        public List<Step> Steps { get; set; }

        public Scenario()
        {
            Steps = new List<Step>();
        }
    }

    public static class ScenarioManager
    {
        public static Scenario GetScenario(int id)
        {
            switch (id)
            {
                case 0:
                    return new Scenario
                    {
                        VariantId = 0,
                        Incident = "На сервер поступает подозрительный трафик.",
                        StartTime = DateTime.Today.AddHours(8),
                        Steps = new List<Step>
                        {
                        new Step
                        {
                            Question = "Какие действия предпринять когда на сервер поступает подозрительный трафик?",
                            Table = "Действия при подозрительном трафике",
                            Options = new List<Option>
                            {
                                new Option { Text = "Запустить анализ сетевого трафика (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Сетевой админ" }, Description = "Фиксация объема, источников и типов подозрительного трафика" },
                                new Option { Text = "Уведомить команду ИБ (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Передача инцидента на уровень реагирования" },
                                new Option { Text = "Ограничить входящий трафик через фаервол (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Временные правила фильтрации для ограничения угроз" },
                                new Option { Text = "Перевести сервер в изолированный режим (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "Сисадмин" }, Description = "Отключение от внешних сетей без остановки внутренних процессов" }
                            }
                        },
                        new Step
                        {
                            Question = "Какие данные следует собрать для анализа?",
                            Table = "Данные для анализа",
                            Options = new List<Option>
                            {
                                new Option { Text = "Логи фаервола (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сетевой админ" }, Description = "Источники, порты, частота обращений" },
                                new Option { Text = "Логи IDS/IPS (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-специалист" }, Description = "Аномалии и сигнатуры угроз" },
                                new Option { Text = "Снимки состояния сервера (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Текущие подключения, процессы, сетевые сокеты" },
                                new Option { Text = "Сетевые дампы (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Подробная запись сетевых пакетов для последующего анализа" }
                            }
                        },
                        new Step
                        {
                            Question = "Как подтвердить или опровергнуть факт атаки?",
                            Table = "Как подтвердить или опровергнуть атаку",
                            Options = new List<Option>
                            {
                                new Option { Text = "Проверить логи SIEM-системы (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "ИБ-специалист" }, Description = "Корреляция событий из разных источников" },
                                new Option { Text = "Провести поведенческий анализ (3ч, 700₽)", TimeHours = 3, Cost = 700, Resources = new List<string> { "ИБ-аналитик" }, Description = "Поиск отклонений от нормальной работы сервера" },
                                new Option { Text = "Сравнить активность с базой угроз (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Использование Threat Intelligence для сопоставления паттернов" },
                                new Option { Text = "Запросить внешний аудит (5ч, 2000₽)", TimeHours = 5, Cost = 2000, Resources = new List<string> { "Аудитор" }, Description = "Привлечение сторонней экспертизы для верификации инцидента" }
                            }
                        },
                        new Step
                        {
                            Question = "Как действовать при подтверждении атаки?",
                            Table = "Действия при атаки",
                            Options = new List<Option>
                            {
                                new Option { Text = "Блокировать IP-адреса источников (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сетевой админ" }, Description = "Оперативная защита от текущих атакующих" },
                                new Option { Text = "Отключить сервер от сети (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Прекращение связи сервера до полной очистки" },
                                new Option { Text = "Применить готовый план реагирования (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "ИБ-специалист" }, Description = "Активизация заранее утвержденной процедуры реагирования" },
                                new Option { Text = "Начать форензик-анализ сервера (5ч, 3000₽)", TimeHours = 5, Cost = 3000, Resources = new List<string> { "ИБ-специалист" }, Description = "Техническое расследование для установления причин и последствий" }
                            }
                        },
                        new Step
                        {
                            Question = "Какие меры предпринять для предотвращения повторных инцидентов?",
                            Table = "Действия для предотвращения повторных инцидентов",
                            Options = new List<Option>
                            {
                                new Option { Text = "Настроить автоматическое оповещение (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Уведомление при аномальной активности" },
                                new Option { Text = "Усилить правила фаервола (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Сетевой админ" }, Description = "Более строгие правила фильтрации" },
                                new Option { Text = "Внедрить WAF (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "ИБ-специалист" }, Description = "Web Application Firewall для защиты приложений" },
                                new Option { Text = "Провести пентест (5ч, 5000₽)", TimeHours = 5, Cost = 5000, Resources = new List<string> { "ИБ-аудитор" }, Description = "Оценка защищенности инфраструктуры внешними специалистами" }
                            }
                        },
                        new Step
                        {
                            Question = "Какие действия предпринять для восстановления работоспособности сервера?",
                            Table = "Действия при востановлении работоспособности сервера",
                            Options = new List<Option>
                            {
                                new Option { Text = "Провести контрольную очистку и перезапуск сервисов (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "Сисадмин" }, Description = "Восстановление функционирования с устранением потенциальных изменений" },
                                new Option { Text = "Выполнить откат к контрольной точке (3ч, 800₽)", TimeHours = 3, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Возврат к безопасной конфигурации из резервной копии" },
                                new Option { Text = "Провести пересборку инстанса с нуля (5ч, 2500₽)", TimeHours = 5, Cost = 2500, Resources = new List<string> { "Сисадмин" }, Description = "Переустановка и настройка с соблюдением безопасных практик" },
                                new Option { Text = "Передать узел в сегмент контролируемого наблюдения (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Наблюдение за поведением сервера до полного ввода в эксплуатацию" }
                            }
                        },
                        new Step
                        {
                            Question = "Какие внутренние коммуникации следует провести после инцидента?",
                            Table = "Коммуникации",
                            Options = new List<Option>
                            {
                                new Option { Text = "Информировать руководство о результатах реагирования (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Предоставление отчета с описанием угроз, действий и текущего статуса" },
                                new Option { Text = "Созвать экстренное совещание ИТ-департамента (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИТ-менеджер" }, Description = "Обсуждение уроков и корректирующих мер" },
                                new Option { Text = "Обновить внутренние регламенты реагирования (3ч, 600₽)", TimeHours = 3, Cost = 600, Resources = new List<string> { "Юрист", "Менеджер ИБ" }, Description = "Приведение процедур в соответствие с выявленными пробелами" },
                                new Option { Text = "Подготовить уведомление для заинтересованных сторон (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "PR-менеджер" }, Description = "Сообщение клиентам, партнерам или регулятору при необходимости" }
                            }
                        },
                        new Step
                        {
                            Question = "Нужно ли провести аудит после инцидента?",
                            Table = "Действия после инцидента",
                            Options = new List<Option>
                            {
                                new Option { Text = "Полный аудит инфраструктуры (6ч, 3000₽)", TimeHours = 6, Cost = 3000, Resources = new List<string> { "ИБ-аудитор" }, Description = "Проверка всех компонентов на предмет уязвимостей и сбоев" },
                                new Option { Text = "Аудит сетевых политик (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "ИБ-специалист" }, Description = "Анализ правил доступа, NAT, ACL и маршрутизации" },
                                new Option { Text = "Проверка прав доступа (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Проверка корректности назначенных прав и учетных записей" },
                                new Option { Text = "Ограничиться техническим отчетом (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Фиксация технических деталей без глубокого анализа" }
                            }
                        },
                        new Step
                        {
                            Question = "Как использовать инцидент для повышения зрелости безопасности?",
                            Table = "Действия по повышении безопасности",
                            Options = new List<Option>
                            {
                                new Option { Text = "Организовать тренинг по реагированию (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "Тренер", "ИБ-специалист" }, Description = "Обучение сотрудников процедурам быстрого реагирования" },
                                new Option { Text = "Актуализировать карту угроз (2ч, 700₽)", TimeHours = 2, Cost = 700, Resources = new List<string> { "ИБ-аналитик" }, Description = "Обновление реестра угроз с учетом инцидента" },
                                new Option { Text = "Провести стратегическую сессию по ИБ (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "CISO", "ИТ-директор" }, Description = "Формирование новых приоритетов и мер в стратегии ИБ" },
                                new Option { Text = "Внедрить процесс пост-инцидентного анализа (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "ИБ-менеджер" }, Description = "Регулярная оценка инцидентов и корректировка процессов" }
                            }
                        }

                        }
                    };
//                case 1:
//                    return new Scenario
//                    {
//                        VariantId = 1,
//                        Incident = "Обнаружено несанкционированное подключение к сети.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                            {
//                                new Step
//                                {
//                                    Question = "Что делать с несанкционированным подключением?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Отключить устройство немедленно", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой администратор" }, Description = "Физическое или программное отключение неизвестного устройства" },
//                                        new Option { Text = "Провести расследование", TimeHours = 10, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Детальное изучение инцидента и возможных последствий" },
//                                        new Option { Text = "Изолировать сегмент сети", TimeHours = 3, Cost = 800, Resources = new List<string> { "Сетевой администратор" }, Description = "Ограничить доступ изолированной части сети" },
//                                        new Option { Text = "Сообщить руководство", TimeHours = 2, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Передать информацию руководству для дальнейших решений" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Какое оборудование использовать для блокировки?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Аппаратный файрволл (3ч, 700₽)", TimeHours = 3, Cost = 700, Resources = new List<string> { "Сетевой администратор" }, Description = "Использование физического устройства для фильтрации трафика" },
//                                        new Option { Text = "Программный фильтр (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Системный администратор" }, Description = "Настройка программных правил блокировки подключения" },
//                                        new Option { Text = "VPN-сегментация (5ч, 1500₽)", TimeHours = 5, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Разделение сетей с помощью VPN для изоляции угроз" },
//                                        new Option { Text = "Аутсорсинг защиты (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Привлечение сторонней компании для настройки блокировок" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Кто будет контролировать ситуацию?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Ответственный администратор (4ч, 1000₽)", TimeHours = 4, Cost = 1000, Resources = new List<string> { "Администратор" }, Description = "Назначение одного администратора для наблюдения" },
//                                        new Option { Text = "Команда ИБ (2ч, 2500₽)", TimeHours = 2, Cost = 2500, Resources = new List<string> { "Все" }, Description = "Совместный контроль специалистами по информационной безопасности" },
//                                        new Option { Text = "Стажер под контролем (6ч, 150₽)", TimeHours = 6, Cost = 150, Resources = new List<string> { "Стажер", "Администратор" }, Description = "Контроль ситуации стажером с куратором" },
//                                        new Option { Text = "Внешняя компания (3ч, 3000₽)", TimeHours = 3, Cost = 3000, Resources = new List<string> { "Подрядчик" }, Description = "Передача контроля сторонней организации" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Проводить ли аудит безопасности после?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Полный аудит (8ч, 4000₽)", TimeHours = 8, Cost = 4000, Resources = new List<string> { "ИБ-специалист" }, Description = "Всеобъемлющая проверка всей ИТ-инфраструктуры" },
//                                        new Option { Text = "Только основные службы (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "Администратор" }, Description = "Проверка ключевых компонентов системы" },
//                                        new Option { Text = "Минимальный аудит (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string>(), Description = "Быстрая базовая проверка на наличие проблем" },
//                                        new Option { Text = "Аудит сторонней фирмой (4ч, 2500₽)", TimeHours = 4, Cost = 2500, Resources = new List<string> { "Подрядчик" }, Description = "Независимая экспертиза состояния ИБ" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Подготовить отчет о происшествии?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Полный отчет (4ч, 1500₽)", TimeHours = 4, Cost = 1500, Resources = new List<string> { "Менеджер" }, Description = "Подробное документирование всех этапов инцидента" },
//                                        new Option { Text = "Краткий отчет (2ч, 700₽)", TimeHours = 2, Cost = 700, Resources = new List<string> { "Стажер" }, Description = "Краткое описание сути и решения инцидента" },
//                                        new Option { Text = "Сделать с помощью ИИ (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "GPT :)" }, Description = "Автоматическая генерация отчета нейросетью" },
//                                        new Option { Text = "Диктовать специалисту (3ч, 800₽)", TimeHours = 3, Cost = 800, Resources = new List<string> { "ИБ-специалист" }, Description = "Устный отчёт с оформлением ассистентом" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Как вы поступите с подозрительным трафиком?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Перезагрузить сервер", TimeHours = 4, Cost = 500, Resources = new List<string> { "Сисадмин" }, Description = "Сброс работы сервера без анализа угрозы" },
//                                        new Option { Text = "Изолировать и провести анализ", TimeHours = 16, Cost = 1200, Resources = new List<string> { "ИБ-специалист", "Сканер" }, Description = "Отключение от сети и анализ источника угрозы" },
//                                        new Option { Text = "Сообщить начальству", TimeHours = 10, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Уведомление руководства о возможной атаке" },
//                                        new Option { Text = "Сделать дамп трафика", TimeHours = 2, Cost = 250, Resources = new List<string> { "ИБ-специалист" }, Description = "Сбор сетевых данных для последующего анализа" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Что использовать для анализа?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Wireshark (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Использование сетевого анализатора Wireshark для изучения трафика" },
//                                        new Option { Text = "Firewall-логи (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>(), Description = "Анализ логов межсетевого экрана" },
//                                        new Option { Text = "Антивирусный сканер (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сканер" }, Description = "Проверка на вредоносное ПО антивирусным сканером" },
//                                        new Option { Text = "Внешний сервис (4ч, 1000₽)", TimeHours = 4, Cost = 1000, Resources = new List<string> { "Поставщик" }, Description = "Передача данных на анализ стороннему сервису" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Кто будет заниматься решением проблемы?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Внутренний ИБ-специалист (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "ИБ-специалист" }, Description = "Поручение задачи штатному специалисту по безопасности" },
//                                        new Option { Text = "Вся команда (1ч, 3000₽)", TimeHours = 1, Cost = 3000, Resources = new List<string> { "Все" }, Description = "Мобилизация всей команды на устранение проблемы" },
//                                        new Option { Text = "Стажер под наблюдением (6ч, 100₽)", TimeHours = 6, Cost = 100, Resources = new List<string> { "Стажер", "Куратор" }, Description = "Передача задачи стажеру с обязательным контролем" },
//                                        new Option { Text = "Аутсорс (2ч, 2000₽)", TimeHours = 2, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Привлечение внешней компании для решения инцидента" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Нужна ли проверка системы после устранения?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Да, провести сканирование (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "Сканер" }, Description = "Полная проверка всей системы после устранения" },
//                                        new Option { Text = "Только внешние порты (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string>(), Description = "Ограниченная проверка только входящих соединений" },
//                                        new Option { Text = "Проверка логов и активностей (1ч, 400₽)", TimeHours = 1, Cost = 400, Resources = new List<string> { "ИБ-специалист" }, Description = "Анализ активности пользователей и событий безопасности" },
//                                        new Option { Text = "Контрольное тестирование (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Администратор" }, Description = "Проверка функционирования систем после восстановления" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Следует ли инициировать внутренний аудит ИБ?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Да, срочный аудит (4ч, 2500₽)", TimeHours = 4, Cost = 2500, Resources = new List<string> { "ИБ-специалист", "Менеджер" }, Description = "Полная проверка текущего состояния безопасности" },
//                                        new Option { Text = "Плановый аудит позже (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Description = "Аудит будет проведён в будущем согласно графику" },
//                                        new Option { Text = "Поручить внешний аудит (3ч, 4000₽)", TimeHours = 3, Cost = 4000, Resources = new List<string> { "Подрядчик" }, Description = "Независимая оценка уровня защищенности" },
//                                        new Option { Text = "Инициировать только по согласованию (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Проведение только после одобрения руководства" }
//                                    }
//                                },
//                                new Step
//                                {
//                                    Question = "Каким образом хранить артефакты инцидента?",
//                                    Options = new List<Option>
//                                    {
//                                        new Option { Text = "Сохранить в зашифрованном архиве (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Безопасное хранение данных для возможного расследования" },
//                                        new Option { Text = "Отправить в CERT (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Менеджер" }, Description = "Передача материалов в национальный центр реагирования" },
//                                        new Option { Text = "Архивировать на изолированное хранилище (1ч, 250₽)", TimeHours = 1, Cost = 250, Resources = new List<string> { "Администратор" }, Description = "Хранение в офлайн-хранилище для исключения доступа" },
//                                        new Option { Text = "Перенести в защищённую облачную среду (1ч, 400₽)", TimeHours = 1, Cost = 400, Resources = new List<string> { "ИБ-специалист" }, Description = "Хранение в облаке с доступом по MFA" }
//                                    }
//                                }

//                            }
//                    };
//                case 2:
//                    return new Scenario
//                    {
//                        VariantId = 2,
//                        Incident = "Обнаружена подозрительная активность в учетной записи сотрудника.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какое первичное действие предпринять после обнаружения подозрительной активности в учетной записи сотрудника?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Временно заблокировать учетную запись (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Администратор" }, Description = "Отключение доступа до выяснения обстоятельств" },
//                                    new Option { Text = "Запросить подтверждение личности сотрудника (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "HR", "Менеджер" }, Description = "Проверка, действительно ли сотрудник осуществлял действия" },
//                                    new Option { Text = "Изолировать рабочее устройство (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Сисадмин" }, Description = "Отключение устройства от сети для анализа" },
//                                    new Option { Text = "Уведомить ИБ-команду (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Эскалация инцидента специалистам ИБ" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие данные необходимо собрать?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Логи активности учетной записи (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Анализ входов и действий пользователя" },
//                                    new Option { Text = "История изменений данных (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Проверка, были ли попытки изменения или удаления данных" },
//                                    new Option { Text = "Снимки сессии (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Получение скриншотов или дампов активности" },
//                                    new Option { Text = "Данные сетевых соединений (1ч, 250₽)", TimeHours = 1, Cost = 250, Resources = new List<string> { "Сетевой админ" }, Description = "Фиксация подозрительных подключений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как проверить легитимность действий?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сравнить с рабочими задачами (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Анализ действий на соответствие должностным обязанностям" },
//                                    new Option { Text = "Опросить сотрудника (0.5ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "HR" }, Description = "Получение пояснений от сотрудника" },
//                                    new Option { Text = "Проверить аутентификацию (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Анализ логов входа и подтверждений MFA" },
//                                    new Option { Text = "Запустить внутреннюю проверку (4ч, 1200₽)", TimeHours = 4, Cost = 1200, Resources = new List<string> { "ИБ-специалист" }, Description = "Формальный процесс валидации действий" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как действовать, если подтвержден несанкционированный доступ?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сбросить пароли (0.5ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Сисадмин" }, Description = "Принудительная смена всех учетных данных" },
//                                    new Option { Text = "Откатить изменения (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Сисадмин" }, Description = "Восстановление затронутых данных" },
//                                    new Option { Text = "Начать служебное расследование (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string> { "HR", "Менеджер" }, Description = "Анализ инцидента и возможной вины сотрудника" },
//                                    new Option { Text = "Сообщить регуляторам (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Юрист" }, Description = "Обязательная отчетность в случае утечки данных" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какой инструмент использовать для дальнейшего анализа?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "SIEM-система (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "ИБ-специалист" }, Description = "Использование системы централизованного логирования и анализа событий" },
//                                    new Option { Text = "EDR-платформа (2ч, 1500₽)", TimeHours = 2, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Средства реагирования на угрозы на рабочих станциях" },
//                                    new Option { Text = "PowerShell-скрипт (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Администратор" }, Description = "Ручной сбор информации с устройства" },
//                                    new Option { Text = "Форензика с помощью FTK (5ч, 3000₽)", TimeHours = 5, Cost = 3000, Resources = new List<string> { "ИБ-специалист" }, Description = "Полноценное судебно-экспертное расследование" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как контролировать дальнейшую активность пользователя?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Включить дополнительный аудит действий (1ч, 400₽)", TimeHours = 1, Cost = 400, Resources = new List<string> { "Сисадмин" }, Description = "Повышенный уровень журналирования активности" },
//                                    new Option { Text = "Ограничить доступ к критическим системам (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Администратор" }, Description = "Ограничение прав до выяснения обстоятельств" },
//                                    new Option { Text = "Назначить куратора из ИБ (2ч, 700₽)", TimeHours = 2, Cost = 700, Resources = new List<string> { "ИБ-специалист" }, Description = "Индивидуальный контроль действий сотрудника" },
//                                    new Option { Text = "Перевести на карантинный профиль (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Работа в ограниченной среде без доступа к конфиденциальным данным" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Следует ли изменить политики безопасности?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Усилить парольную политику (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Администратор" }, Description = "Увеличение длины и сложности паролей" },
//                                    new Option { Text = "Включить обязательную MFA (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Двухфакторная аутентификация для всех пользователей" },
//                                    new Option { Text = "Ограничить доступ по IP (1ч, 250₽)", TimeHours = 1, Cost = 250, Resources = new List<string> { "Сетевой админ" }, Description = "Фильтрация доступа по списку доверенных адресов" },
//                                    new Option { Text = "Ввести периодический мониторинг сессий (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Регулярный контроль текущих пользовательских сессий" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Кому следует отчитаться о результатах?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Руководителю отдела (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Отчет по инциденту для непосредственного начальника" },
//                                    new Option { Text = "Совету по ИБ (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "ИБ-специалист", "Менеджер" }, Description = "Плановое информирование специализированной группы" },
//                                    new Option { Text = "Службе персонала (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "HR" }, Description = "Передача информации для возможных дисциплинарных действий" },
//                                    new Option { Text = "Внешнему заказчику (1ч, 500₽)", TimeHours = 1, Cost = 500, Resources = new List<string> { "Менеджер", "Юрист" }, Description = "Сообщение контрагенту при необходимости" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Хранить ли результаты расследования?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Да, в защищенном архиве (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Шифрованное архивирование данных для аудита" },
//                                    new Option { Text = "Да, на внутреннем сервере (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Администратор" }, Description = "Хранение на изолированном ресурсе" },
//                                    new Option { Text = "Отправить в юридический отдел (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Юрист" }, Description = "Для возможного использования в разбирательствах" },
//                                    new Option { Text = "Удалить по завершении (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>(), Description = "Соблюдение политики минимального хранения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Проводить ли обучающий разбор инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Да, для ИТ-отдела (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "ИБ-специалист" }, Description = "Обучение на основе произошедшего инцидента" },
//                                    new Option { Text = "Да, для всех сотрудников (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "HR", "Менеджер" }, Description = "Повышение осведомленности пользователей" },
//                                    new Option { Text = "Нет, только внутренний отчет (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Ограниченное распространение информации" },
//                                    new Option { Text = "Подготовить обучающее видео (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "HR", "Видеопродакшн" }, Description = "Масштабируемый обучающий материал" }
//                                }
//                            }
//                        }
//                    };
//                case 3:
//                    return new Scenario
//                    {
//                        VariantId = 3,
//                        Incident = "На сервере базы данных зафиксированы следы внешнего вмешательства.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Что необходимо сделать, когда на сервере базы данных зафиксированы следы внешнего вмешательства?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отключить сервер от сети (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Изоляция сервера для предотвращения дальнейших атак" },
//                                    new Option { Text = "Уведомить CISO и эскалировать инцидент (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер", "ИБ-специалист" }, Description = "Передача информации ответственным за безопасность" },
//                                    new Option { Text = "Запустить процедуру инцидент-менеджмента (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Формальный запуск процесса реагирования по внутреннему регламенту" },
//                                    new Option { Text = "Назначить ответственного за расследование (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Определение координатора инцидента" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какую информацию следует собрать для оценки ущерба?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Снимок памяти сервера (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Дамп оперативной памяти для поиска следов атакующего" },
//                                    new Option { Text = "Логи SQL-сервера (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Анализ активности в СУБД" },
//                                    new Option { Text = "Сетевые логи за последние 24 часа (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Сетевой админ" }, Description = "Отслеживание подозрительных подключений" },
//                                    new Option { Text = "Список всех изменений в БД (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Сисадмин" }, Description = "Проверка возможной подмены данных" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как обеспечить непрерывность бизнеса?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Восстановить БД из последней резервной копии (4ч, 800₽)", TimeHours = 4, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Временное возвращение к стабильному состоянию" },
//                                    new Option { Text = "Перенести сервисы на резервный сервер (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "Сисадмин" }, Description = "Сокращение времени простоя" },
//                                    new Option { Text = "Ввести ручную обработку заявок (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Операторы" }, Description = "Продолжение операций без ИТ-систем" },
//                                    new Option { Text = "Закрыть доступ к системе до устранения последствий (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Ограничение использования для предотвращения ошибок" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как действовать, если установлено, что данные были скомпрометированы?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Оповестить всех затронутых клиентов (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер", "Юрист" }, Description = "Выполнение обязательств по прозрачности и соответствие регламентам" },
//                                    new Option { Text = "Сообщить регулятору (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Юрист" }, Description = "Сообщение в надзорные органы в установленные сроки" },
//                                    new Option { Text = "Предложить компенсации пострадавшим (3ч, 3000₽)", TimeHours = 3, Cost = 3000, Resources = new List<string> { "Менеджер", "Юрист" }, Description = "Формирование пакета предложений для клиентов" },
//                                    new Option { Text = "Обратиться в правоохранительные органы (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Юрист" }, Description = "Возбуждение официального расследования" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры применить для устранения уязвимости?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Установить обновления и патчи (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Сисадмин" }, Description = "Закрытие известных уязвимостей" },
//                                    new Option { Text = "Провести аудит конфигурации (3ч, 700₽)", TimeHours = 3, Cost = 700, Resources = new List<string> { "ИБ-специалист" }, Description = "Поиск нестандартных или уязвимых настроек" },
//                                    new Option { Text = "Внедрить WAF перед сервером (4ч, 1500₽)", TimeHours = 4, Cost = 1500, Resources = new List<string> { "Сетевой админ" }, Description = "Дополнительный уровень защиты на периметре" },
//                                    new Option { Text = "Отключить устаревшие службы (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Удаление потенциально уязвимых компонентов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как предотвратить подобные инциденты в будущем?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Разработать план реагирования на инциденты (5ч, 0₽)", TimeHours = 5, Cost = 0, Resources = new List<string> { "Менеджер", "ИБ-специалист" }, Description = "Документированный порядок действий при аналогичных инцидентах" },
//                                    new Option { Text = "Провести обучение команды (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "HR", "ИБ-специалист" }, Description = "Повышение уровня кибергигиены персонала" },
//                                    new Option { Text = "Внедрить автоматизированный мониторинг (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "Сетевой админ" }, Description = "Постоянный анализ активности для выявления аномалий" },
//                                    new Option { Text = "Провести внешний аудит ИБ (6ч, 5000₽)", TimeHours = 6, Cost = 5000, Resources = new List<string> { "Внешний консультант" }, Description = "Объективная оценка текущей защиты" }
//                                }
//                            }
//                        }
//                    };
//                case 4:
//                    return new Scenario
//                    {
//                        VariantId = 4,
//                        Incident = "Обнаружена подозрительная активность на рабочей станции сотрудника",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные меры следует предпринять при обнаружении подозрительной активности на рабочей станции сотрудника?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Изолировать рабочую станцию от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Ограничение дальнейшего распространения угрозы" },
//                                    new Option { Text = "Уведомить сотрудника и руководство (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Оповещение ответственных лиц" },
//                                    new Option { Text = "Запустить мониторинг активности (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-аналитик" }, Description = "Фиксация всех действий на рабочей станции" },
//                                    new Option { Text = "Сделать снимок текущего состояния системы (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Снимок процессов, файлов, подключений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие данные следует собрать для глубокого анализа инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Логи антивируса и EDR-системы (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-специалист" }, Description = "Поиск вредоносных индикаторов и активности" },
//                                    new Option { Text = "Анализ системных событий Windows (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Регистрация процессов и входов в систему" },
//                                    new Option { Text = "Извлечь дамп памяти (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Анализ активных процессов и возможных внедрений" },
//                                    new Option { Text = "Собрать сетевые логи и трафик (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Сетевой админ" }, Description = "Отслеживание подозрительных соединений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как подтвердить или опровергнуть факт компрометации рабочей станции?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить контрольные суммы системных файлов (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Выявление изменений и модификаций" },
//                                    new Option { Text = "Провести анализ поведения пользователя (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "ИБ-аналитик" }, Description = "Сравнение активности с типичными паттернами" },
//                                    new Option { Text = "Сопоставить индикаторы компрометации с базой угроз (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Использование Threat Intelligence" },
//                                    new Option { Text = "Заказать внешний аудит и форензик-экспертизу (5ч, 2500₽)", TimeHours = 5, Cost = 2500, Resources = new List<string> { "Аудитор" }, Description = "Внешняя проверка и подтверждение" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять при подтверждении инцидента на рабочей станции?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отключить рабочую станцию от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Прекращение внешних коммуникаций" },
//                                    new Option { Text = "Начать форензик-анализ (5ч, 3000₽)", TimeHours = 5, Cost = 3000, Resources = new List<string> { "ИБ-специалист" }, Description = "Техническое расследование для установления источника и масштабов" },
//                                    new Option { Text = "Применить план восстановления и реагирования (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Менеджер ИБ" }, Description = "Активизация процедур инцидент-менеджмента" },
//                                    new Option { Text = "Оповестить внутренние службы и руководство (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Информирование о масштабах и планах действий" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для восстановления безопасности и работоспособности станции?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести переустановку ОС и программного обеспечения (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "Сисадмин" }, Description = "Обеспечение чистой рабочей среды" },
//                                    new Option { Text = "Восстановить данные из резервных копий (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Сисадмин" }, Description = "Возврат к безопасному состоянию данных" },
//                                    new Option { Text = "Усилить средства защиты и мониторинга (2ч, 1200₽)", TimeHours = 2, Cost = 1200, Resources = new List<string> { "ИБ-специалист" }, Description = "Установка EDR и усиление политики доступа" },
//                                    new Option { Text = "Перевести рабочую станцию под постоянный контроль (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-аналитик" }, Description = "Наблюдение за поведением и предупреждение повторений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие внутренние коммуникации и отчеты следует организовать по инциденту?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подготовить отчет для руководства (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Документирование инцидента и действий" },
//                                    new Option { Text = "Провести внутренний брифинг с ИТ и ИБ командами (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИТ-менеджер" }, Description = "Обсуждение уроков и корректирующих мер" },
//                                    new Option { Text = "Обновить процедуры реагирования (3ч, 700₽)", TimeHours = 3, Cost = 700, Resources = new List<string> { "Менеджер ИБ", "Юрист" }, Description = "Корректировка регламентов по результатам инцидента" },
//                                    new Option { Text = "Подготовить уведомление для сотрудников и партнёров (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "PR-менеджер" }, Description = "Информирование заинтересованных сторон" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Следует ли проводить дополнительный аудит и оценку уязвимостей в инфраструктуре?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести комплексный аудит ИТ-инфраструктуры (6ч, 3500₽)", TimeHours = 6, Cost = 3500, Resources = new List<string> { "ИБ-аудитор" }, Description = "Выявление скрытых уязвимостей" },
//                                    new Option { Text = "Аудит политик безопасности (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "Менеджер ИБ" }, Description = "Проверка актуальности и исполнения политик" },
//                                    new Option { Text = "Проверка прав доступа пользователей (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Обеспечение принципа минимальных прав" },
//                                    new Option { Text = "Анализ соответствия требованиям регуляторов (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "Юрист", "ИБ-специалист" }, Description = "Юридическая и нормативная проверка" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия помогут повысить уровень подготовки сотрудников после инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Организовать тренинг по кибергигиене и реагированию (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "Тренер", "Менеджер ИБ" }, Description = "Обучение сотрудников профилактике инцидентов" },
//                                    new Option { Text = "Провести имитацию инцидента (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "ИБ-аналитик" }, Description = "Практическое отработывание процедур" },
//                                    new Option { Text = "Выпустить рассылку с рекомендациями (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Информирование сотрудников" },
//                                    new Option { Text = "Оценить осведомленность сотрудников анкетированием (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "HR", "ИБ-аналитик" }, Description = "Оценка эффективности обучения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры реализовать для предотвращения повторения подобных инцидентов?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Усилить контроль доступа и внедрить двухфакторную аутентификацию (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "Сисадмин" }, Description = "Повышение безопасности доступа" },
//                                    new Option { Text = "Регулярные обновления и патчи для всех систем (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Закрытие уязвимостей" },
//                                    new Option { Text = "Мониторинг и автоматическое оповещение о подозрительной активности (4ч, 1500₽)", TimeHours = 4, Cost = 1500, Resources = new List<string> { "ИБ-аналитик" }, Description = "Раннее обнаружение угроз" },
//                                    new Option { Text = "Внедрить политику сегментации сети (5ч, 2000₽)", TimeHours = 5, Cost = 2000, Resources = new List<string> { "Сетевой админ" }, Description = "Ограничение распространения инцидентов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Каковы следующие шаги для закрытия инцидента и фиксации результатов расследования?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подготовить финальный отчет с рекомендациями (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Документирование всего процесса и уроков" },
//                                    new Option { Text = "Провести встречу с заинтересованными сторонами (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер ИБ" }, Description = "Обсуждение итогов и дальнейших действий" },
//                                    new Option { Text = "Архивировать материалы расследования (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Сохранение для возможных проверок" },
//                                    new Option { Text = "Обновить планы и процедуры реагирования (3ч, 700₽)", TimeHours = 3, Cost = 700, Resources = new List<string> { "Менеджер ИБ" }, Description = "Адаптация процессов к новым условиям" }
//                                }
//                            }
//                        }
//                    };

//                case 5:
//                    return new Scenario
//                    {
//                        VariantId = 5,
//                        Incident = "Критическое оборудование в дата-центре вышло из строя, что угрожает непрерывности бизнес-процессов.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Что необходимо сделать в первую очередь при отказе критического оборудования в дата-центре?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Активировать аварийный протокол (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИТ-менеджер" }, Description = "Запуск согласованных процедур экстренного реагирования" },
//                                    new Option { Text = "Созвать антикризисную команду (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Координатор", "ИТ-менеджер" }, Description = "Формирование единого центра принятия решений" },
//                                    new Option { Text = "Перевести сервисы на резервную платформу (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Инженер" }, Description = "Обеспечение доступности бизнес-функций" },
//                                    new Option { Text = "Проинформировать руководство о сбое (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер по коммуникациям" }, Description = "Эскалация инцидента и управление вниманием" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие данные необходимо оперативно собрать?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Логи сбоя и систем мониторинга (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Системный инженер" }, Description = "Идентификация причины сбоя" },
//                                    new Option { Text = "Отчеты о работоспособности резервов (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИТ-аналитик" }, Description = "Анализ доступных альтернатив" },
//                                    new Option { Text = "Финансовые риски и возможные убытки (1ч, 350₽)", TimeHours = 1, Cost = 350, Resources = new List<string> { "Финансовый аналитик" }, Description = "Поддержка принятия управленческих решений" },
//                                    new Option { Text = "Информация о статусе сервисов (1ч, 150₽)", TimeHours = 1, Cost = 150, Resources = new List<string> { "ИТ-менеджер" }, Description = "Обновление картины инцидента" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия необходимо предпринять для минимизации последствий?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Ограничить доступ к второстепенным системам (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Системный администратор" }, Description = "Оптимизация ресурсов" },
//                                    new Option { Text = "Запустить режим временной деградации (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИТ-архитектор" }, Description = "Поддержка основных функций при частичном отказе" },
//                                    new Option { Text = "Перевести часть функций в облако (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "Облачный инженер" }, Description = "Поддержание доступности критических сервисов" },
//                                    new Option { Text = "Организовать ручное выполнение бизнес-процессов (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Операционный персонал" }, Description = "Поддержка клиентов при технологическом сбое" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как диагностировать причины отказа оборудования?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести технический аудит (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Вендор", "Инженер" }, Description = "Комплексная диагностика аппаратной неисправности" },
//                                    new Option { Text = "Использовать журнал событий и датчиков (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИТ-аналитик" }, Description = "Оценка цепочки событий, приведших к сбою" },
//                                    new Option { Text = "Связаться с производителем для консультации (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер по оборудованию" }, Description = "Поддержка от производителя и рекомендации" },
//                                    new Option { Text = "Организовать внутреннее расследование (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "ИТ-аудитор" }, Description = "Поиск организационных и процедурных сбоев" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как обеспечить эффективную коммуникацию в ходе кризиса?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Назначить ответственного за кризисные коммуникации (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "PR-менеджер" }, Description = "Централизация управления информацией" },
//                                    new Option { Text = "Подготовить шаблоны сообщений для клиентов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "PR-менеджер" }, Description = "Снижение паники и управление доверием" },
//                                    new Option { Text = "Организовать регулярные брифинги (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИТ-менеджер", "Руководство" }, Description = "Актуальная информация для всех участников" },
//                                    new Option { Text = "Запустить внутренний канал обновлений (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Коммуникационный координатор" }, Description = "Поддержка вовлеченности сотрудников" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия следует предпринять после восстановления инфраструктуры?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести постинцидентный анализ (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "ИТ-менеджер", "Аналитик" }, Description = "Выводы и улучшения процессов" },
//                                    new Option { Text = "Отчет о действиях и затратах (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Финансовый аналитик" }, Description = "Финансовая оценка кризиса" },
//                                    new Option { Text = "Оценить соответствие SLA (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер по контрактам" }, Description = "Сопоставление факта и обязательств" },
//                                    new Option { Text = "Провести опрос персонала (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "HR" }, Description = "Оценка внутренней реакции на инцидент" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие долгосрочные меры следует внедрить для устойчивости?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Инвестировать в модернизацию оборудования (8ч, 15000₽)", TimeHours = 8, Cost = 15000, Resources = new List<string> { "Закупщик", "Инженер" }, Description = "Устранение технических узких мест" },
//                                    new Option { Text = "Разработать план управления ИТ-рисками (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Риск-менеджер" }, Description = "Снижение уязвимостей" },
//                                    new Option { Text = "Внедрить мультидата-центрную стратегию (10ч, 20000₽)", TimeHours = 10, Cost = 20000, Resources = new List<string> { "ИТ-директор" }, Description = "Отказоустойчивость на архитектурном уровне" },
//                                    new Option { Text = "Внедрить политику регулярного тестирования BCP (3ч, 900₽)", TimeHours = 3, Cost = 900, Resources = new List<string> { "Аудитор" }, Description = "Поддержка актуальности планов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие изменения в процессах необходимо провести?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Пересмотреть внутренние процедуры инцидент-менеджмента (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "Менеджер по качеству" }, Description = "Повышение эффективности реагирования" },
//                                    new Option { Text = "Оптимизировать цепочку эскалаций (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер по операциям" }, Description = "Сокращение времени реагирования" },
//                                    new Option { Text = "Актуализировать роли и зоны ответственности (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "HR", "Руководство" }, Description = "Повышение прозрачности" },
//                                    new Option { Text = "Создать внутренний регламент управления непрерывностью (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Юрист", "ИТ-менеджер" }, Description = "Закрепление стандартов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как усилить осведомлённость сотрудников и обучить их действиям при сбоях?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести тренинг по плану действий при сбоях (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "Тренер" }, Description = "Формирование устойчивой культуры реагирования" },
//                                    new Option { Text = "Выпустить справочник по действиям при ЧС (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "HR", "PR-менеджер" }, Description = "Информационная доступность" },
//                                    new Option { Text = "Провести имитационные учения (4ч, 2500₽)", TimeHours = 4, Cost = 2500, Resources = new List<string> { "ИТ-менеджер", "Координатор" }, Description = "Отработка навыков в условиях стресса" },
//                                    new Option { Text = "Оценить готовность сотрудников к действиям при сбое (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "HR", "ИТ-менеджер" }, Description = "Мониторинг уровня подготовки" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие стратегические выводы можно сделать по итогам инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Инициировать пересмотр всей ИТ-стратегии (4ч, 2500₽)", TimeHours = 4, Cost = 2500, Resources = new List<string> { "ИТ-директор" }, Description = "Интеграция уроков кризиса в развитие ИТ" },
//                                    new Option { Text = "Внести инцидент в корпоративный реестр рисков (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Риск-менеджер" }, Description = "Формализация опыта" },
//                                    new Option { Text = "Провести стратегическую сессию с руководством (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "Руководство" }, Description = "Оценка уязвимостей бизнеса" },
//                                    new Option { Text = "Подготовить презентацию для совета директоров (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер по ИТ", "PR" }, Description = "Прозрачность управления ситуацией" }
//                                }
//                            }
//                        }
//                    };
//                case 6:
//                    return new Scenario
//                    {
//                        VariantId = 6,
//                        Incident = "Сотрудник случайно отправил внутренний документ внешнему получателю.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Как следует отреагировать на факт случайной передачи конфиденциальной информации?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Оповестить команду информационной безопасности (0.5ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Своевременная эскалация инцидента специалистам" },
//                                    new Option { Text = "Изолировать канал утечки (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой админ" }, Description = "Ограничение доступа к информации, если это еще возможно" },
//                                    new Option { Text = "Связаться с получателем и запросить удаление (0.5ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер", "Юрист" }, Description = "Попытка минимизации ущерба" },
//                                    new Option { Text = "Отключить учетную запись сотрудника (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Превентивное ограничение доступа до выяснения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для фиксации инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Зарегистрировать инцидент в системе ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Создание формализованной записи для дальнейшего анализа" },
//                                    new Option { Text = "Задокументировать отправленное сообщение (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Фиксация содержания и адресата" },
//                                    new Option { Text = "Собрать технические логи отправки (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Анализ действий пользователя и системы" },
//                                    new Option { Text = "Запросить скриншоты или подтверждение действий сотрудника (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "HR" }, Description = "Подтверждение обстоятельств происшествия" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как определить критичность утечки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Оценить классификацию данных (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-аналитик" }, Description = "Проверка наличия конфиденциальной или персональной информации" },
//                                    new Option { Text = "Провести внутреннюю оценку бизнес-рисков (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "Менеджер" }, Description = "Оценка воздействия на бизнес-процессы и репутацию" },
//                                    new Option { Text = "Проверить соответствие данным политике обработки (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Юрист" }, Description = "Нарушены ли регламенты или законодательство" },
//                                    new Option { Text = "Сравнить инцидент с аналогичными в прошлом (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Поиск паттернов и ошибок в процессах" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие шаги предпринять для юридического реагирования?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проанализировать риски ответственности (1ч, 400₽)", TimeHours = 1, Cost = 400, Resources = new List<string> { "Юрист" }, Description = "Проверка последствий по закону" },
//                                    new Option { Text = "Подготовить юридическое уведомление получателю (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Юрист" }, Description = "Официальное требование об удалении данных" },
//                                    new Option { Text = "Консультироваться с регулятором (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "Юрист" }, Description = "Оценка обязательства уведомления госорганов" },
//                                    new Option { Text = "Проверить соблюдение GDPR/152-ФЗ (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Юрист", "ИБ-специалист" }, Description = "Комплаенс-анализ на предмет персональных данных" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как взаимодействовать с сотрудником, допустившим ошибку?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести разъяснительную беседу (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "HR", "Менеджер" }, Description = "Уточнение обстоятельств и предупреждение в будущем" },
//                                    new Option { Text = "Назначить дисциплинарную проверку (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "HR" }, Description = "Проверка на факт нарушения внутренних политик" },
//                                    new Option { Text = "Оценить нагрузку и условия работы (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "HR" }, Description = "Выявление системных причин ошибки" },
//                                    new Option { Text = "Временно ограничить доступ к чувствительной информации (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Минимизация потенциальных рисков" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие процессы следует пересмотреть в связи с инцидентом?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Актуализировать политику информационной безопасности (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист", "Юрист" }, Description = "Корректировка регламентов по защите информации" },
//                                    new Option { Text = "Добавить механизмы проверки адресатов (3ч, 800₽)", TimeHours = 3, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Техническая защита от ошибочной отправки" },
//                                    new Option { Text = "Внедрить DLP-систему (5ч, 4000₽)", TimeHours = 5, Cost = 4000, Resources = new List<string> { "ИБ-специалист" }, Description = "Контроль утечек данных на уровне инфраструктуры" },
//                                    new Option { Text = "Пересмотреть процесс проверки документов (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Менеджер" }, Description = "Добавление этапа ручного или автоматического контроля" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как минимизировать последствия утечки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести оценку вероятного ущерба (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Менеджер", "Юрист" }, Description = "Расчет потенциальных последствий для бизнеса" },
//                                    new Option { Text = "Информировать партнера о ошибке (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Открытое признание ошибки для сохранения доверия" },
//                                    new Option { Text = "Ограничить использование канала связи (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой админ" }, Description = "Временное отключение почтового сервера или фильтрация" },
//                                    new Option { Text = "Выпустить официальное внутреннее уведомление (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер", "HR" }, Description = "Контроль за распространением слухов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие долгосрочные меры можно внедрить для предотвращения подобных инцидентов?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Организовать регулярное обучение по ИБ (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "HR", "ИБ-специалист" }, Description = "Формирование культуры безопасности" },
//                                    new Option { Text = "Внедрить предупреждение при внешней отправке (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Системное напоминание при внешнем адресате" },
//                                    new Option { Text = "Настроить шифрование и контроль пересылки (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Защита даже при утечке" },
//                                    new Option { Text = "Регулярно проверять эффективность политики ИБ (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-специалист" }, Description = "Анализ инцидентов и корректировка подходов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Кому следует направить отчет о результатах расследования?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Руководству подразделения (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Информирование непосредственного руководства" },
//                                    new Option { Text = "Юридическому отделу (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Юрист" }, Description = "Для оценки правовых последствий" },
//                                    new Option { Text = "Команде ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Информация для корректировки мер защиты" },
//                                    new Option { Text = "Комплаенс-офицеру (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Комплаенс-менеджер" }, Description = "Оценка нарушения внутренних и внешних регламентов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Следует ли использовать инцидент для обучения персонала?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Да, провести внутренний кейс-разбор (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "HR", "Менеджер" }, Description = "Обсуждение ошибки и выводов" },
//                                    new Option { Text = "Подготовить обучающее письмо (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "HR" }, Description = "Рассылка с напоминанием по правилам" },
//                                    new Option { Text = "Добавить кейс в базу знаний (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Использование для будущих обучений" },
//                                    new Option { Text = "Нет, ограничиться служебной запиской (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Минимальное документирование" }
//                                }
//                            }
//                        }
//                    };
//                case 7:
//                    return new Scenario
//                    {
//                        VariantId = 7,
//                        Incident = "Обнаружено вредоносное ПО на рабочем компьютере сотрудника.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия нужно выполнить при обнаружении заражения на рабочем ПК?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Изолировать устройство от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Быстрое отключение от сети для предотвращения распространения" },
//                                    new Option { Text = "Сообщить в отдел информационной безопасности (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сотрудник" }, Description = "Передача инцидента для оценки рисков и реагирования" },
//                                    new Option { Text = "Перевести сотрудника на резервное устройство (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИТ-отдел" }, Description = "Обеспечение непрерывности работы" },
//                                    new Option { Text = "Запустить антивирусную проверку (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Сисадмин" }, Description = "Попытка первичной нейтрализации угрозы" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Каким образом провести технический анализ зараженного устройства?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сделать дамп памяти и диск для анализа (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Создание копий для последующего изучения без риска потери следов" },
//                                    new Option { Text = "Исследовать систему вручную (3ч, 400₽)", TimeHours = 3, Cost = 400, Resources = new List<string> { "ИБ-аналитик" }, Description = "Поиск следов вручную через лог-файлы и процессы" },
//                                    new Option { Text = "Передать образ подрядчику (1ч, 1500₽)", TimeHours = 1, Cost = 1500, Resources = new List<string> { "Подрядчик" }, Description = "Передача профессионалам для глубокой аналитики" },
//                                    new Option { Text = "Использовать sandbox-окружение (2ч, 700₽)", TimeHours = 2, Cost = 700, Resources = new List<string> { "ИБ-специалист" }, Description = "Запуск зараженного ПО в безопасной среде" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры помогут определить масштаб заражения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сканировать сеть на предмет аналогичных признаков (4ч, 800₽)", TimeHours = 4, Cost = 800, Resources = new List<string> { "Сетевой админ" }, Description = "Поиск других зараженных хостов" },
//                                    new Option { Text = "Анализировать почтовый трафик (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-аналитик" }, Description = "Проверка возможного распространения через письма" },
//                                    new Option { Text = "Проверить журналы прокси-сервера (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Анализ выходящего трафика" },
//                                    new Option { Text = "Опросить пользователей (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "ИТ-отдел" }, Description = "Проверка наличия схожих симптомов у других сотрудников" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры стоит предпринять для устранения угрозы с зараженного ПК?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Переустановить ОС (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Сисадмин" }, Description = "Полное удаление вредоносного ПО" },
//                                    new Option { Text = "Использовать специализированные утилиты (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Удаление вредоносного ПО без переустановки" },
//                                    new Option { Text = "Восстановить систему из образа (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИТ-отдел" }, Description = "Восстановление с резервной копии" },
//                                    new Option { Text = "Передать на лабораторное лечение (4ч, 1200₽)", TimeHours = 4, Cost = 1200, Resources = new List<string> { "Подрядчик" }, Description = "Глубокое лечение зараженной системы экспертами" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Каким образом следует уведомить руководство о киберинциденте?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Составить краткий отчет (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Менеджер" }, Description = "Быстрое информирование о сути инцидента" },
//                                    new Option { Text = "Подготовить расширенный отчет с деталями (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист", "Менеджер" }, Description = "Полное описание ситуации и предпринятых действий" },
//                                    new Option { Text = "Провести очную встречу (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист", "HR" }, Description = "Устное обсуждение и ответ на вопросы" },
//                                    new Option { Text = "Отправить служебную записку (1ч, 50₽)", TimeHours = 1, Cost = 50, Resources = new List<string> { "Менеджер" }, Description = "Формальное оповещение без подробностей" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия следует применить в отношении сотрудника, чей ПК был заражен?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести инструктаж по безопасности (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "HR", "ИБ-специалист" }, Description = "Обучение по предотвращению подобных ситуаций" },
//                                    new Option { Text = "Назначить повторное обучение по ИБ (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "HR" }, Description = "Формальное переобучение" },
//                                    new Option { Text = "Ограничить доступ к критичным ресурсам (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Временное снижение прав доступа" },
//                                    new Option { Text = "Провести служебную проверку (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "HR" }, Description = "Установление факта халатности или злого умысла" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предотвратят повторное заражение рабочих станций?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Обновить антивирус на всех ПК (3ч, 600₽)", TimeHours = 3, Cost = 600, Resources = new List<string> { "Сисадмин" }, Description = "Обеспечение актуальной защиты" },
//                                    new Option { Text = "Ограничить установку ПО без разрешения (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-специалист" }, Description = "Запрет на инсталляцию без одобрения" },
//                                    new Option { Text = "Настроить контроль внешних устройств (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Сетевой админ" }, Description = "Блокировка запуска заражённых флешек" },
//                                    new Option { Text = "Установить почтовую фильтрацию вложений (2ч, 700₽)", TimeHours = 2, Cost = 700, Resources = new List<string> { "ИБ-специалист" }, Description = "Предотвращение доставки вредоносных файлов через почту" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как следует информировать другие отделы об инциденте с заражением?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Да, отправить уведомление в ИТ и ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Предупреждение смежных команд о возможных последствиях" },
//                                    new Option { Text = "Провести общее собрание по безопасности (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "HR", "ИБ-специалист" }, Description = "Обсуждение инцидента с коллективом" },
//                                    new Option { Text = "Разослать внутреннюю инструкцию (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "HR" }, Description = "Обновление практик безопасности среди сотрудников" },
//                                    new Option { Text = "Ограничиться уведомлением менеджеров отделов (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Информирование ответственных лиц без широкого распространения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какой метод восстановления данных с зараженного ПК выбрать после очистки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Восстановить с резервной копии (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИТ-отдел" }, Description = "Гарантированно чистая система" },
//                                    new Option { Text = "Переустановить ОС и вручную вернуть данные (3ч, 600₽)", TimeHours = 3, Cost = 600, Resources = new List<string> { "Сисадмин" }, Description = "Чистая установка и копирование данных с проверкой" },
//                                    new Option { Text = "Использовать облачный профиль сотрудника (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИТ-отдел" }, Description = "Быстрое восстановление через облако" },
//                                    new Option { Text = "Выдать новое устройство и архивировать старое (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "ИТ-отдел" }, Description = "Минимизация рисков повторного заражения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для документирования и завершения инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Завести карточку инцидента в системе управления (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Формальная регистрация и фиксация выводов" },
//                                    new Option { Text = "Добавить инцидент в базу кейсов (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Менеджер", "ИБ-аналитик" }, Description = "Аналитическая ценность для будущих сценариев" },
//                                    new Option { Text = "Подготовить отчёт для регулятора (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Юрист", "ИБ-специалист" }, Description = "Соблюдение нормативных требований" },
//                                    new Option { Text = "Проанализировать эффективность принятых мер (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-аналитик" }, Description = "Оценка качества реагирования и принятие мер по улучшению" }
//                                }
//                            }
//                        }
//                    };
//                case 8:
//                    return new Scenario
//                    {
//                        VariantId = 8,
//                        Incident = "В дата-центре произошло отключение системы охлаждения, что угрожает перегревом критического оборудования.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия нужно выполнить при обнаружении отключения системы охлаждения в дата-центре?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сообщить в технический отдел (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Дежурный инженер" }, Description = "Немедленное уведомление ответственных специалистов" },
//                                    new Option { Text = "Активировать резервную систему охлаждения (1ч, 500₽)", TimeHours = 1, Cost = 500, Resources = new List<string> { "Техник" }, Description = "Запуск резервного оборудования для снижения температуры" },
//                                    new Option { Text = "Отключить часть серверов для снижения тепловой нагрузки (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Снижение нагрузки для замедления перегрева" },
//                                    new Option { Text = "Вызвать аварийную службу (1ч, 1000₽)", TimeHours = 1, Cost = 1000, Resources = new List<string> { "Аварийная бригада" }, Description = "Внешняя помощь в восстановлении системы" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как провести оценку текущего состояния оборудования при перегреве?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить температурные датчики (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Техник" }, Description = "Сбор данных о температуре для анализа" },
//                                    new Option { Text = "Провести визуальный осмотр серверных стоек (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Техник" }, Description = "Определение критических зон нагрева" },
//                                    new Option { Text = "Запросить отчёт систем мониторинга (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Проверка логов температур и нагрузки" },
//                                    new Option { Text = "Провести тепловизионное обследование (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Техник" }, Description = "Поиск точек перегрева с помощью тепловизора" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры можно принять для временного снижения температуры?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Использовать переносные кондиционеры (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "Техник" }, Description = "Быстрое охлаждение временными средствами" },
//                                    new Option { Text = "Открыть доступ к прохладному воздуху извне (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Дежурный инженер" }, Description = "Экстренное проветривание" },
//                                    new Option { Text = "Установить дополнительные вентиляторы (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Техник" }, Description = "Усиление воздушного потока" },
//                                    new Option { Text = "Перенести часть нагрузки в облако (3ч, 2000₽)", TimeHours = 3, Cost = 2000, Resources = new List<string> { "Сисадмин" }, Description = "Снижение тепловыделения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как организовать взаимодействие между командами в условиях инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Назначить ответственного координатора (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Чёткое распределение обязанностей" },
//                                    new Option { Text = "Создать чат для оперативного обмена информацией (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Сокращение времени реакции" },
//                                    new Option { Text = "Проводить брифинги каждые 30 минут (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Оперативный контроль ситуации" },
//                                    new Option { Text = "Использовать систему тикетов для задач (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИТ-отдел" }, Description = "Структурированное распределение задач" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия следует предпринять для предотвращения повреждения данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сделать резервное копирование (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИТ-отдел" }, Description = "Сохранение данных перед отключением" },
//                                    new Option { Text = "Перенести критические данные на удалённый сервер (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Сисадмин" }, Description = "Снижение риска потерь" },
//                                    new Option { Text = "Временно приостановить некритичные процессы (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИТ-отдел" }, Description = "Снижение нагрузки на систему" },
//                                    new Option { Text = "Запустить автоматическое копирование в облако (2ч, 1500₽)", TimeHours = 2, Cost = 1500, Resources = new List<string> { "ИТ-отдел" }, Description = "Дополнительная защита данных" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как информировать руководство о критической ситуации в дата-центре?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подготовить краткий доклад (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Оперативное донесение сути проблемы" },
//                                    new Option { Text = "Составить развернутый отчёт (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Менеджер" }, Description = "Подробное описание ситуации" },
//                                    new Option { Text = "Организовать видеоконференцию (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Личное обсуждение" },
//                                    new Option { Text = "Отправить служебную записку (1ч, 50₽)", TimeHours = 1, Cost = 50, Resources = new List<string> { "Менеджер" }, Description = "Формальное уведомление" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие технические меры помогут восстановить работу системы охлаждения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Перезапустить контроллер охлаждения (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Техник" }, Description = "Восстановление работоспособности системы" },
//                                    new Option { Text = "Заменить неисправный модуль (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "Техник" }, Description = "Полный ремонт оборудования" },
//                                    new Option { Text = "Подключить внешний чиллер (4ч, 5000₽)", TimeHours = 4, Cost = 5000, Resources = new List<string> { "Аварийная бригада" }, Description = "Временное охлаждение" },
//                                    new Option { Text = "Вызвать подрядчика для ремонта (2ч, 2000₽)", TimeHours = 2, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Профессиональный ремонт" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для предотвращения подобных инцидентов в будущем?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Установить датчики температуры с тревогой (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Техник" }, Description = "Автоматическое оповещение при перегреве" },
//                                    new Option { Text = "Провести профилактическое обслуживание системы охлаждения (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "Техник" }, Description = "Снижение риска поломок" },
//                                    new Option { Text = "Настроить автоматический запуск резервной системы (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "Техник" }, Description = "Бесперебойная работа" },
//                                    new Option { Text = "Разработать план реагирования на отказ охлаждения (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Менеджер" }, Description = "Чёткий порядок действий" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как задокументировать и закрыть инцидент с перегревом?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Составить отчёт по инциденту (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Официальная фиксация событий" },
//                                    new Option { Text = "Добавить кейс в базу знаний (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Учёт для будущих инцидентов" },
//                                    new Option { Text = "Проанализировать эффективность действий (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "ИБ-аналитик" }, Description = "Оценка принятых мер" },
//                                    new Option { Text = "Подготовить отчёт для регулятора (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Юрист" }, Description = "Соблюдение требований" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для защиты персонала при перегреве оборудования?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Ограничить доступ в серверную (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Охрана" }, Description = "Снижение риска для сотрудников" },
//                                    new Option { Text = "Выдать средства индивидуальной защиты (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Отдел охраны труда" }, Description = "Защита здоровья" },
//                                    new Option { Text = "Организовать временную рабочую зону в безопасном месте (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "HR" }, Description = "Перенос рабочих мест" },
//                                    new Option { Text = "Провести инструктаж по безопасности (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "HR" }, Description = "Повышение осведомлённости" }
//                                }
//                            }
//                        }
//                    };
//                case 9:
//                    return new Scenario
//                    {
//                        VariantId = 9,
//                        Incident = "На корпоративный веб-сервис началась масштабная DDoS-атака, из-за которой сайт недоступен для клиентов.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия необходимо выполнить при обнаружении DDoS-атаки на веб-сервис?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сообщить в отдел информационной безопасности (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Оператор" }, Description = "Мгновенное уведомление ответственных специалистов" },
//                                    new Option { Text = "Отключить сервис от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сетевой админ" }, Description = "Прекращение доступа для защиты инфраструктуры" },
//                                    new Option { Text = "Активировать встроенные средства защиты сервера (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Сисадмин" }, Description = "Включение фильтрации на уровне ОС" },
//                                    new Option { Text = "Переключить трафик на резервный канал (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Временный обход атакуемого канала связи" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Каким образом можно быстро подтвердить факт DDoS-атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить сетевую статистику на маршрутизаторах (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сетевой админ" }, Description = "Анализ трафика на пиковые нагрузки" },
//                                    new Option { Text = "Использовать систему мониторинга (1ч, 50₽)", TimeHours = 1, Cost = 50, Resources = new List<string> { "Сисадмин" }, Description = "Проверка логов и оповещений" },
//                                    new Option { Text = "Сравнить трафик с историческими показателями (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-аналитик" }, Description = "Выявление аномалий" },
//                                    new Option { Text = "Запросить отчёт у провайдера (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Подтверждение атаки внешними данными" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры помогут минимизировать воздействие атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Включить гео-фильтрацию трафика (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой админ" }, Description = "Ограничение доступа из определённых стран" },
//                                    new Option { Text = "Применить rate limiting (1ч, 150₽)", TimeHours = 1, Cost = 150, Resources = new List<string> { "Сисадмин" }, Description = "Ограничение количества запросов от одного клиента" },
//                                    new Option { Text = "Использовать облачный сервис фильтрации (2ч, 2000₽)", TimeHours = 2, Cost = 2000, Resources = new List<string> { "ИБ-специалист" }, Description = "Передача трафика через облачные фильтры" },
//                                    new Option { Text = "Временно отключить неключевые сервисы (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Снижение нагрузки на сервер" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Каким образом уведомить руководство о DDoS-атаке?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отправить экстренное сообщение в чат (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Мгновенное информирование" },
//                                    new Option { Text = "Составить краткий отчёт о ситуации (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Менеджер" }, Description = "Передача ключевой информации" },
//                                    new Option { Text = "Организовать видеоконференцию (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Обсуждение действий в реальном времени" },
//                                    new Option { Text = "Отправить служебную записку по почте (1ч, 50₽)", TimeHours = 1, Cost = 50, Resources = new List<string> { "Менеджер" }, Description = "Формальное документирование" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для сбора доказательств атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сохранить логи серверов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Фиксация исходных данных" },
//                                    new Option { Text = "Сделать дамп сетевого трафика (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Получение полной картины атаки" },
//                                    new Option { Text = "Зафиксировать показатели мониторинга (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-аналитик" }, Description = "Сохранение графиков нагрузки" },
//                                    new Option { Text = "Запросить данные у интернет-провайдера (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Получение независимых доказательств" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для восстановления доступности веб-сервиса?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Перенести сервис на резервный сервер (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "Сисадмин" }, Description = "Временный запуск на другой площадке" },
//                                    new Option { Text = "Подключить CDN (2ч, 1500₽)", TimeHours = 2, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Снижение нагрузки через распределённые узлы" },
//                                    new Option { Text = "Ограничить доступ по IP (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой админ" }, Description = "Фильтрация трафика" },
//                                    new Option { Text = "Восстановить сервис из резервной копии (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИТ-отдел" }, Description = "Возврат к последнему рабочему состоянию" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как информировать клиентов о временной недоступности сервиса?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Разместить уведомление на соцсетях (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "PR-отдел" }, Description = "Публичное оповещение" },
//                                    new Option { Text = "Отправить email-рассылку клиентам (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "PR-отдел" }, Description = "Прямое уведомление" },
//                                    new Option { Text = "Обновить страницу статуса (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИТ-отдел" }, Description = "Публикация актуальной информации" },
//                                    new Option { Text = "Позвонить ключевым клиентам (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Персональное уведомление" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для предотвращения повторных атак?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Настроить постоянный анти-DDoS сервис (3ч, 5000₽)", TimeHours = 3, Cost = 5000, Resources = new List<string> { "ИБ-специалист" }, Description = "Постоянная защита от атак" },
//                                    new Option { Text = "Обновить прошивку сетевого оборудования (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "Сетевой админ" }, Description = "Закрытие известных уязвимостей" },
//                                    new Option { Text = "Реализовать балансировку нагрузки (3ч, 2000₽)", TimeHours = 3, Cost = 2000, Resources = new List<string> { "Сисадмин" }, Description = "Распределение трафика между серверами" },
//                                    new Option { Text = "Разработать план реагирования на DDoS (4ч, 800₽)", TimeHours = 4, Cost = 800, Resources = new List<string> { "ИБ-аналитик" }, Description = "Регламент действий при повторных атаках" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как зафиксировать и закрыть инцидент DDoS-атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подготовить отчёт по инциденту (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-аналитик" }, Description = "Описание хода атаки и принятых мер" },
//                                    new Option { Text = "Внести инцидент в базу знаний (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Использование опыта в будущем" },
//                                    new Option { Text = "Организовать разбор полётов (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-специалист", "ИТ-отдел" }, Description = "Разбор ошибок и улучшение реагирования" },
//                                    new Option { Text = "Подготовить пресс-релиз (2ч, 400₽)", TimeHours = 2, Cost = 400, Resources = new List<string> { "PR-отдел" }, Description = "Информационное сообщение для СМИ" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие долгосрочные меры усилят защиту от DDoS-атак?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Заключить договор с провайдером защиты от атак (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Менеджер" }, Description = "Постоянная поддержка от стороннего поставщика" },
//                                    new Option { Text = "Внедрить систему анализа поведения пользователей (4ч, 2500₽)", TimeHours = 4, Cost = 2500, Resources = new List<string> { "ИБ-аналитик" }, Description = "Раннее выявление аномалий" },
//                                    new Option { Text = "Провести обучение персонала реагированию на инциденты (3ч, 800₽)", TimeHours = 3, Cost = 800, Resources = new List<string> { "HR", "ИБ-специалист" }, Description = "Повышение готовности команды" },
//                                    new Option { Text = "Регулярно тестировать защиту (2ч, 1200₽)", TimeHours = 2, Cost = 1200, Resources = new List<string> { "ИБ-специалист" }, Description = "Проверка эффективности мер" }
//                                }
//                            }
//                        }
//                    };
//                case 10:
//                    return new Scenario
//                    {
//                        VariantId = 10,
//                        Incident = "В корпоративной сети обнаружено массовое распространение шифровальщика, блокирующего файлы сотрудников.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия нужно выполнить при обнаружении заражения шифровальщиком в сети?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отключить заражённые компьютеры от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Предотвращение дальнейшего распространения вируса" },
//                                    new Option { Text = "Сообщить в отдел ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Оператор" }, Description = "Мгновенное уведомление специалистов по безопасности" },
//                                    new Option { Text = "Изолировать заражённый сегмент сети (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Ограничение доступа заражённых устройств" },
//                                    new Option { Text = "Запустить антивирусное сканирование (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Проверка на наличие угроз" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как быстро подтвердить факт заражения шифровальщиком?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить расширения файлов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Выявление зашифрованных данных" },
//                                    new Option { Text = "Анализировать логи антивируса (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Подтверждение обнаружения угроз" },
//                                    new Option { Text = "Использовать утилиты для определения типа шифровальщика (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-аналитик" }, Description = "Определение конкретного вида вируса" },
//                                    new Option { Text = "Собрать жалобы пользователей (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Служба поддержки" }, Description = "Получение первичной информации от сотрудников" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для локализации угрозы?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отключить интернет-доступ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сетевой админ" }, Description = "Прекращение передачи данных злоумышленникам" },
//                                    new Option { Text = "Заблокировать подозрительные процессы (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Остановка работы вируса" },
//                                    new Option { Text = "Использовать сегментацию сети (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Изоляция заражённых машин" },
//                                    new Option { Text = "Перевести сотрудников на резервные устройства (4ч, 1000₽)", TimeHours = 4, Cost = 1000, Resources = new List<string> { "ИТ-отдел" }, Description = "Продолжение работы без доступа к заражённым ПК" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как уведомить руководство о киберинциденте?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отправить экстренное уведомление (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Мгновенное информирование" },
//                                    new Option { Text = "Организовать собрание кризисного штаба (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Обсуждение стратегии действий" },
//                                    new Option { Text = "Составить краткий отчёт (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Менеджер" }, Description = "Документирование ситуации" },
//                                    new Option { Text = "Позвонить ключевым лицам (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Персональное информирование" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие шаги предпринять для остановки работы вируса?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Запустить специализированную утилиту удаления (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Полное удаление шифровальщика" },
//                                    new Option { Text = "Откатить систему на предыдущую точку восстановления (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Возврат к рабочему состоянию" },
//                                    new Option { Text = "Переставить ОС (4ч, 200₽)", TimeHours = 4, Cost = 200, Resources = new List<string> { "ИТ-отдел" }, Description = "Полная переустановка" },
//                                    new Option { Text = "Использовать изолированную загрузочную флешку (2ч, 100₽)", TimeHours = 2, Cost = 100, Resources = new List<string> { "Сисадмин" }, Description = "Очистка диска от вируса" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как собрать доказательства и данные о заражении?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сохранить логи событий (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-аналитик" }, Description = "Фиксация информации о заражении" },
//                                    new Option { Text = "Сделать образ жёсткого диска (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Сохранение текущего состояния" },
//                                    new Option { Text = "Зафиксировать активные процессы (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Сбор сведений о работе вируса" },
//                                    new Option { Text = "Получить отчёт от антивируса (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Документирование заражения" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для восстановления данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Восстановить из резервной копии (4ч, 1000₽)", TimeHours = 4, Cost = 1000, Resources = new List<string> { "ИТ-отдел" }, Description = "Возврат к рабочим файлам" },
//                                    new Option { Text = "Использовать ПО для расшифровки (5ч, 500₽)", TimeHours = 5, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Попытка вернуть данные" },
//                                    new Option { Text = "Передать диски в лабораторию (6ч, 2000₽)", TimeHours = 6, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Профессиональное восстановление" },
//                                    new Option { Text = "Восстановить вручную критичные файлы (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string> { "ИТ-отдел" }, Description = "Частичное восстановление" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как информировать сотрудников о ситуации?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Разослать инструкции по безопасности (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "PR-отдел" }, Description = "Предупреждение новых заражений" },
//                                    new Option { Text = "Организовать обучающий вебинар (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Разъяснение ситуации" },
//                                    new Option { Text = "Отправить сообщение по внутреннему чату (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Мгновенное оповещение" },
//                                    new Option { Text = "Выдать памятки по кибербезопасности (2ч, 100₽)", TimeHours = 2, Cost = 100, Resources = new List<string> { "PR-отдел" }, Description = "Закрепление мер предосторожности" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры принять для предотвращения повторного заражения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Обновить антивирусное ПО (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Закрытие уязвимостей" },
//                                    new Option { Text = "Внедрить EDR-систему (4ч, 5000₽)", TimeHours = 4, Cost = 5000, Resources = new List<string> { "ИБ-специалист" }, Description = "Постоянный мониторинг угроз" },
//                                    new Option { Text = "Ограничить права пользователей (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Снижение риска заражения" },
//                                    new Option { Text = "Провести плановое обучение сотрудников (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "HR-отдел" }, Description = "Повышение осведомлённости" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как зафиксировать и закрыть инцидент с шифровальщиком?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подготовить подробный отчёт (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "ИБ-аналитик" }, Description = "Документирование атаки и мер" },
//                                    new Option { Text = "Внести запись в журнал инцидентов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Учёт инцидента" },
//                                    new Option { Text = "Разработать план реагирования на подобные атаки (4ч, 800₽)", TimeHours = 4, Cost = 800, Resources = new List<string> { "ИБ-специалист" }, Description = "Повышение готовности" },
//                                    new Option { Text = "Провести послеситуационный разбор (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИТ-отдел" }, Description = "Анализ действий и ошибок" }
//                                }
//                            }
//                        }
//                    };
//                case 11:
//                    return new Scenario
//                    {
//                        VariantId = 11,
//                        Incident = "На сервере веб-приложения обнаружена утечка конфиденциальных данных из-за эксплуатация уязвимости в коде.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия нужно выполнить при обнаружении утечки данных на сервере веб-приложения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отключить сервер от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Предотвращение дальнейшей утечки" },
//                                    new Option { Text = "Заблокировать подозрительные IP-адреса (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Сетевой админ" }, Description = "Ограничение доступа злоумышленников" },
//                                    new Option { Text = "Сообщить в отдел ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Оператор" }, Description = "Мгновенное уведомление специалистов" },
//                                    new Option { Text = "Запустить аварийный план реагирования (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-менеджер" }, Description = "Активизация процедур защиты" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как оперативно подтвердить факт утечки данных с сервера?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить логи веб-сервера (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-аналитик" }, Description = "Анализ подозрительных запросов" },
//                                    new Option { Text = "Сравнить текущие данные с резервными копиями (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Выявление изменений" },
//                                    new Option { Text = "Использовать утилиты для анализа сетевого трафика (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Фиксация передачи данных" },
//                                    new Option { Text = "Собрать показания от разработчиков (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Разработчик" }, Description = "Выявление аномалий в работе" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для локализации инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Закрыть доступ к уязвимому модулю (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Разработчик" }, Description = "Исключение эксплуатаций" },
//                                    new Option { Text = "Отключить API до устранения уязвимости (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Прекращение утечки" },
//                                    new Option { Text = "Перенаправить трафик на резервный сервер (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string> { "Сетевой админ" }, Description = "Сохранение доступности сервиса" },
//                                    new Option { Text = "Ограничить доступ по VPN (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Снижение числа точек входа" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как уведомить руководство и заинтересованные стороны о факте утечки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Разослать экстренное уведомление (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Быстрое информирование" },
//                                    new Option { Text = "Организовать внеочередное собрание (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-менеджер" }, Description = "Обсуждение мер реагирования" },
//                                    new Option { Text = "Составить краткий технический отчёт (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "ИБ-аналитик" }, Description = "Документирование ситуации" },
//                                    new Option { Text = "Позвонить ключевым партнёрам (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Персональное информирование" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для устранения уязвимости?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Исправить код веб-приложения (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string> { "Разработчик" }, Description = "Устранение ошибки" },
//                                    new Option { Text = "Обновить серверное ПО (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Закрытие эксплуатаций" },
//                                    new Option { Text = "Установить веб-фаервол (5ч, 500₽)", TimeHours = 5, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Фильтрация опасных запросов" },
//                                    new Option { Text = "Провести код-ревью модуля (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string> { "Разработчик" }, Description = "Поиск аналогичных ошибок" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как собрать доказательства для расследования инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сохранить логи сервера (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-аналитик" }, Description = "Фиксация обращений к системе" },
//                                    new Option { Text = "Сделать дамп базы данных (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Сисадмин" }, Description = "Сохранение текущего состояния" },
//                                    new Option { Text = "Записать сетевой трафик (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Выявление каналов утечки" },
//                                    new Option { Text = "Сделать снимки экрана с консоли (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Подтверждение действий" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как минимизировать последствия утечки данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Изменить пароли пользователей (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Блокировка несанкционированного доступа" },
//                                    new Option { Text = "Ограничить доступ к скомпрометированным данным (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "ИБ-специалист" }, Description = "Снижение ущерба" },
//                                    new Option { Text = "Уведомить затронутых клиентов (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string> { "PR-отдел" }, Description = "Снижение репутационных рисков" },
//                                    new Option { Text = "Удалить утёкшие данные из публичных источников (5ч, 1000₽)", TimeHours = 5, Cost = 1000, Resources = new List<string> { "Юрист", "ИБ-специалист" }, Description = "Сокращение распространения информации" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для восстановления работы веб-приложения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Перенести сайт на резервный сервер (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Восстановление доступности" },
//                                    new Option { Text = "Откатить базу данных на резервную копию (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Возврат к безопасной версии" },
//                                    new Option { Text = "Запустить тестирование стабильности (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Разработчик" }, Description = "Проверка работоспособности" },
//                                    new Option { Text = "Восстановить удалённые сервисы (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string> { "ИТ-отдел" }, Description = "Полное возвращение функционала" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры принять для предотвращения подобных атак в будущем?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Внедрить систему WAF (4ч, 500₽)", TimeHours = 4, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Блокировка вредоносных запросов" },
//                                    new Option { Text = "Проводить регулярный пентест (6ч, 2000₽)", TimeHours = 6, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Выявление уязвимостей" },
//                                    new Option { Text = "Обновлять ПО по расписанию (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "Сисадмин" }, Description = "Своевременное закрытие уязвимостей" },
//                                    new Option { Text = "Проводить обучение разработчиков (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "HR-отдел" }, Description = "Снижение рисков в коде" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как зафиксировать и закрыть инцидент с утечкой данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Составить финальный отчёт (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string> { "ИБ-аналитик" }, Description = "Подробное описание событий" },
//                                    new Option { Text = "Внести запись в журнал инцидентов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Официальная фиксация" },
//                                    new Option { Text = "Обновить план реагирования (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИБ-менеджер" }, Description = "Повышение готовности" },
//                                    new Option { Text = "Провести послеситуационный разбор (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string> { "ИТ-отдел" }, Description = "Анализ ошибок" }
//                                }
//                            }
//                        }
//                    };
//                case 12:
//                    return new Scenario
//                    {
//                        VariantId = 12,
//                        Incident = "На корпоративный веб-сайт идёт массированная DDoS-атака, из-за чего ресурс недоступен для клиентов.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия нужно выполнить при обнаружении DDoS-атаки на веб-сайт?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сообщить в отдел ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Оператор" }, Description = "Оповещение специалистов для реагирования" },
//                                    new Option { Text = "Запустить аварийный план реагирования (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Активация заранее подготовленных мер" },
//                                    new Option { Text = "Изолировать атакуемый ресурс от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Временное предотвращение перегрузки" },
//                                    new Option { Text = "Включить защиту на уровне провайдера (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string>{ "Сетевой админ" }, Description = "Фильтрация трафика" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как быстро подтвердить факт DDoS-атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить сетевые логи на предмет аномальной активности (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Фиксация массовых запросов" },
//                                    new Option { Text = "Использовать систему мониторинга трафика (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Подтверждение атаки" },
//                                    new Option { Text = "Сравнить нагрузку с обычными пиковыми значениями (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Анализ отклонений" },
//                                    new Option { Text = "Запросить данные у интернет-провайдера (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Получение внешних подтверждений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для локализации DDoS-атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Ограничить доступ к сайту по географическому признаку (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Блокировка атакующего региона" },
//                                    new Option { Text = "Перенаправить трафик через CDN (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string>{ "ИБ-специалист" }, Description = "Снижение нагрузки" },
//                                    new Option { Text = "Включить фильтрацию запросов по сигнатурам (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Блокировка типичных DDoS-паттернов" },
//                                    new Option { Text = "Ограничить количество запросов на IP (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Снижение интенсивности атаки" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как уведомить руководство и заинтересованные стороны о DDoS-атаке?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отправить экстренное уведомление по email (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Быстрое информирование" },
//                                    new Option { Text = "Организовать оперативное совещание (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Обсуждение плана реагирования" },
//                                    new Option { Text = "Составить краткий отчёт о ситуации (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Документирование атаки" },
//                                    new Option { Text = "Позвонить ключевым клиентам (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Снижение репутационных потерь" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие технические меры применить для защиты от атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Установить и настроить WAF (4ч, 500₽)", TimeHours = 4, Cost = 500, Resources = new List<string>{ "ИБ-специалист" }, Description = "Фильтрация вредоносных запросов" },
//                                    new Option { Text = "Включить защиту на уровне DNS-провайдера (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string>{ "Сетевой админ" }, Description = "Перенаправление и фильтрация трафика" },
//                                    new Option { Text = "Настроить балансировку нагрузки (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Распределение запросов между серверами" },
//                                    new Option { Text = "Активировать фильтры на маршрутизаторах (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Блокировка подозрительных пакетов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как собрать данные для расследования DDoS-атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Сохранить логи сетевого оборудования (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Фиксация параметров атаки" },
//                                    new Option { Text = "Записать образ сетевого трафика (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string>{ "ИБ-специалист" }, Description = "Подробный анализ активности" },
//                                    new Option { Text = "Запросить статистику у провайдера (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Получение информации о масштабах" },
//                                    new Option { Text = "Сохранить скриншоты графиков нагрузки (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Визуальное подтверждение" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как минимизировать последствия атаки для клиентов?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Разместить уведомление на альтернативном домене (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "PR-отдел" }, Description = "Информирование пользователей" },
//                                    new Option { Text = "Предоставить клиентам резервные каналы связи (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Поддержка взаимодействия" },
//                                    new Option { Text = "Переориентировать клиентов на мобильное приложение (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "PR-отдел" }, Description = "Снижение нагрузки на сайт" },
//                                    new Option { Text = "Отправить персональные письма ключевым клиентам (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Удержание доверия" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие шаги выполнить для восстановления нормальной работы сайта?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Восстановить исходную конфигурацию сервера (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Возврат стабильности" },
//                                    new Option { Text = "Провести тестирование после атаки (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string>{ "Разработчик" }, Description = "Проверка работоспособности" },
//                                    new Option { Text = "Перенести ресурс на резервный хостинг (5ч, 500₽)", TimeHours = 5, Cost = 500, Resources = new List<string>{ "Сетевой админ" }, Description = "Повышение доступности" },
//                                    new Option { Text = "Обновить систему защиты (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Укрепление безопасности" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для предотвращения будущих DDoS-атак?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Внедрить постоянный мониторинг трафика (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string>{ "ИБ-специалист" }, Description = "Своевременное обнаружение угроз" },
//                                    new Option { Text = "Настроить автоматические правила блокировки (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Снижение риска перегрузки" },
//                                    new Option { Text = "Заключить договор с провайдером анти-DDoS услуг (5ч, 2000₽)", TimeHours = 5, Cost = 2000, Resources = new List<string>{ "Менеджер" }, Description = "Гарантированная защита" },
//                                    new Option { Text = "Проводить регулярные учения по реагированию (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Повышение готовности" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как зафиксировать и закрыть инцидент DDoS-атаки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Составить итоговый отчёт (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Документирование атаки" },
//                                    new Option { Text = "Внести запись в журнал инцидентов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Официальная фиксация" },
//                                    new Option { Text = "Обновить план реагирования (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Повышение готовности" },
//                                    new Option { Text = "Провести послеситуационный разбор (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИТ-отдел" }, Description = "Выявление ошибок" }
//                                }
//                            }
//                        }
//                    };
//                case 13:
//                    return new Scenario
//                    {
//                        VariantId = 13,
//                        Incident = "На сервере базы данных обнаружено вредоносное ПО, что угрожает целостности и конфиденциальности информации.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия нужно выполнить при обнаружении вредоносного ПО на сервере базы данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Изолировать сервер от сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Предотвращение распространения угрозы" },
//                                    new Option { Text = "Сообщить в отдел ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Оператор" }, Description = "Оповещение специалистов" },
//                                    new Option { Text = "Запустить антивирусное сканирование (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string>{ "Сисадмин" }, Description = "Выявление и удаление вредоносных файлов" },
//                                    new Option { Text = "Активировать план реагирования на киберинциденты (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Организация действий" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как быстро подтвердить факт заражения сервера базы данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить системные логи (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Выявление подозрительных действий" },
//                                    new Option { Text = "Запустить специализированное ПО для анализа (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string>{ "ИБ-специалист" }, Description = "Детальная проверка" },
//                                    new Option { Text = "Сравнить контрольные суммы файлов с эталоном (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Поиск изменений" },
//                                    new Option { Text = "Проверить сетевую активность сервера (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Выявление нежелательных подключений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для локализации заражения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отключить доступ к серверу для всех пользователей (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Ограничение распространения" },
//                                    new Option { Text = "Блокировать подозрительные IP-адреса (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Прекращение атак" },
//                                    new Option { Text = "Перевести сервер в безопасный режим (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Минимизация работы сервисов" },
//                                    new Option { Text = "Отключить неиспользуемые порты (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Сокращение поверхности атаки" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как уведомить руководство и ответственных лиц о заражении сервера базы данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Отправить экстренное уведомление по корпоративной почте (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Быстрое информирование" },
//                                    new Option { Text = "Организовать срочное совещание (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Определение плана действий" },
//                                    new Option { Text = "Подготовить краткий отчёт о ситуации (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Документирование инцидента" },
//                                    new Option { Text = "Проинформировать службу поддержки (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Готовность к обращениям клиентов" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие технические действия выполнить для удаления вредоносного ПО?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Использовать антивирусное ПО (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string>{ "Сисадмин" }, Description = "Удаление вредоносных файлов" },
//                                    new Option { Text = "Провести ручное удаление заражённых файлов (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Точечная очистка" },
//                                    new Option { Text = "Переустановить серверное ПО (5ч, 1000₽)", TimeHours = 5, Cost = 1000, Resources = new List<string>{ "Сисадмин" }, Description = "Чистая установка" },
//                                    new Option { Text = "Восстановить систему из резервной копии (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Быстрое восстановление" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как проверить целостность базы данных после заражения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить контрольные суммы данных (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "DBA" }, Description = "Выявление изменений" },
//                                    new Option { Text = "Сравнить данные с резервной копией (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "DBA" }, Description = "Поиск повреждений" },
//                                    new Option { Text = "Запустить встроенные средства проверки БД (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "DBA" }, Description = "Диагностика состояния" },
//                                    new Option { Text = "Провести тестовые запросы (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "DBA" }, Description = "Проверка работоспособности" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие шаги предпринять для восстановления работы сервера?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Перезагрузить сервер и проверить службы (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Возврат работоспособности" },
//                                    new Option { Text = "Проверить подключения приложений (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Разработчик" }, Description = "Гарантия доступности" },
//                                    new Option { Text = "Восстановить все сервисы (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Полное восстановление" },
//                                    new Option { Text = "Провести тестирование производительности (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Проверка стабильности" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры предпринять для предотвращения повторного заражения?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Обновить антивирус и сигнатуры (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Актуализация защиты" },
//                                    new Option { Text = "Настроить контроль целостности файлов (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Мониторинг изменений" },
//                                    new Option { Text = "Усилить политику доступа к серверу (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Снижение риска" },
//                                    new Option { Text = "Проводить регулярные проверки на вредоносное ПО (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Профилактика угроз" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как документировать и закрыть инцидент заражения сервера базы данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Составить итоговый отчёт (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Фиксация событий" },
//                                    new Option { Text = "Внести запись в журнал инцидентов (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Регистрация" },
//                                    new Option { Text = "Обновить план реагирования (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Учёт опыта" },
//                                    new Option { Text = "Провести послеситуационный анализ (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИТ-отдел" }, Description = "Выявление улучшений" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры принять для повышения осведомленности персонала и предотвращения будущих инцидентов?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Провести обучающий тренинг по безопасности (4ч, 500₽)", TimeHours = 4, Cost = 500, Resources = new List<string>{ "ИБ-менеджер", "Тренер" }, Description = "Обучение сотрудников основам кибербезопасности" },
//                                    new Option { Text = "Рассылать регулярные напоминания и инструкции (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Поддержание внимания к безопасности" },
//                                    new Option { Text = "Провести тестирование сотрудников на знания (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Оценка эффективности обучения" },
//                                    new Option { Text = "Внедрить политику ответственного обращения с данными (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Усиление культуры безопасности" }
//                                }
//                            }
//                        }
//                    };
//                case 14:
//                    return new Scenario
//                    {
//                        VariantId = 14,
//                        Incident = "Обнаружена утечка конфиденциальных данных из внутренней сети организации.",
//                        StartTime = DateTime.Today.AddHours(8),
//                        Steps = new List<Step>
//                        {
//                            new Step
//                            {
//                                Question = "Какие первичные действия необходимо выполнить при обнаружении утечки данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Изолировать поражённые сегменты сети (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Сетевой админ" }, Description = "Остановка дальнейшей утечки" },
//                                    new Option { Text = "Сообщить руководству и отделу ИБ (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер", "ИБ-специалист" }, Description = "Оповещение ответственных" },
//                                    new Option { Text = "Начать аудит доступа к конфиденциальной информации (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Выявление источника утечки" },
//                                    new Option { Text = "Ограничить доступ пользователей к чувствительным данным (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Администратор" }, Description = "Предотвращение дальнейшего доступа" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие методы использовать для выявления источника утечки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Анализ журналов доступа и действий пользователей (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Отслеживание подозрительной активности" },
//                                    new Option { Text = "Провести интервью с персоналом (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Выяснение возможных причин" },
//                                    new Option { Text = "Использовать инструменты мониторинга сетевого трафика (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string>{ "Сетевой админ" }, Description = "Анализ передачи данных" },
//                                    new Option { Text = "Проверить наличие вредоносного ПО на рабочих станциях (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string>{ "Сисадмин" }, Description = "Выявление возможных угроз" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие меры принять для предотвращения дальнейшей утечки?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Пересмотреть и обновить политики доступа (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Усиление контроля" },
//                                    new Option { Text = "Внедрить двухфакторную аутентификацию (4ч, 500₽)", TimeHours = 4, Cost = 500, Resources = new List<string>{ "Сисадмин" }, Description = "Повышение безопасности" },
//                                    new Option { Text = "Установить системы предотвращения утечек данных (DLP) (5ч, 1000₽)", TimeHours = 5, Cost = 1000, Resources = new List<string>{ "ИБ-специалист" }, Description = "Мониторинг и блокировка утечек" },
//                                    new Option { Text = "Провести обучение сотрудников правилам безопасности (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Снижение человеческого фактора" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как уведомить пострадавших и регуляторов о факте утечки данных?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подготовить и отправить уведомления пострадавшим (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Юрист", "Менеджер" }, Description = "Соблюдение требований закона" },
//                                    new Option { Text = "Сообщить в надзорные органы (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Юрист" }, Description = "Выполнение обязательств" },
//                                    new Option { Text = "Опубликовать пресс-релиз (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "PR-специалист" }, Description = "Управление репутацией" },
//                                    new Option { Text = "Подготовить внутренний отчёт по инциденту (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Анализ и выводы" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие шаги предпринять для восстановления нормальной работы систем?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Восстановить настройки доступа (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Администратор" }, Description = "Возвращение к рабочему состоянию" },
//                                    new Option { Text = "Проверить и обновить программное обеспечение (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Сисадмин" }, Description = "Обеспечение безопасности" },
//                                    new Option { Text = "Провести тестирование систем на уязвимости (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Выявление рисков" },
//                                    new Option { Text = "Обновить резервные копии и проверить их целостность (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "DBA" }, Description = "Подготовка к возможным инцидентам" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как документировать инцидент и что включить в отчёт?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Подробное описание инцидента и принятых мер (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-аналитик" }, Description = "Создание полного отчёта" },
//                                    new Option { Text = "Анализ причин и рекомендации по улучшению (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Учет уроков" },
//                                    new Option { Text = "Регистрация инцидента в журнале (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Фиксация для истории" },
//                                    new Option { Text = "Подготовка презентации для руководства (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Информирование высшего руководства" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие действия предпринять для повышения безопасности и предотвращения повторных инцидентов?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Внедрить регулярные аудиты безопасности (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Постоянный контроль" },
//                                    new Option { Text = "Обновлять политики безопасности и процедуры (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Актуализация документов" },
//                                    new Option { Text = "Обучать персонал правилам безопасности (3ч, 300₽)", TimeHours = 3, Cost = 300, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Укрепление культуры безопасности" },
//                                    new Option { Text = "Использовать современные средства защиты (5ч, 1000₽)", TimeHours = 5, Cost = 1000, Resources = new List<string>{ "Сисадмин" }, Description = "Техническое усиление защиты" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Какие рекомендации дать сотрудникам для предотвращения утечек в будущем?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Использовать сложные пароли и менять их регулярно (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Основы безопасности" },
//                                    new Option { Text = "Не передавать конфиденциальную информацию по незащищённым каналам (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Менеджер" }, Description = "Безопасность коммуникаций" },
//                                    new Option { Text = "Сообщать о подозрительной активности (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>{ "Все сотрудники" }, Description = "Проактивный подход" },
//                                    new Option { Text = "Регулярно проходить обучение по информационной безопасности (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Повышение квалификации" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как организовать работу с подрядчиками и внешними сервисами после инцидента?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Проверить договоры и требования по безопасности (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Юрист" }, Description = "Контроль условий сотрудничества" },
//                                    new Option { Text = "Внедрить требования по безопасности в соглашения (3ч, 0₽)", TimeHours = 3, Cost = 0, Resources = new List<string>{ "Юрист", "ИБ-менеджер" }, Description = "Повышение стандартов" },
//                                    new Option { Text = "Проводить регулярные аудиты подрядчиков (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string>{ "ИБ-специалист" }, Description = "Мониторинг соответствия" },
//                                    new Option { Text = "Ограничить доступ подрядчиков к конфиденциальным данным (2ч, 0₽)", TimeHours = 2, Cost = 0, Resources = new List<string>{ "Администратор" }, Description = "Минимизация рисков" }
//                                }
//                            },
//                            new Step
//                            {
//                                Question = "Как подготовиться к возможным будущим инцидентам?",
//                                Options = new List<Option>
//                                {
//                                    new Option { Text = "Разработать план реагирования на инциденты (5ч, 0₽)", TimeHours = 5, Cost = 0, Resources = new List<string>{ "ИБ-менеджер" }, Description = "Структурированный подход" },
//                                    new Option { Text = "Проводить регулярные тренировки и симуляции (4ч, 0₽)", TimeHours = 4, Cost = 0, Resources = new List<string>{ "Все сотрудники" }, Description = "Повышение готовности" },
//                                    new Option { Text = "Обновлять инструменты мониторинга и защиты (3ч, 500₽)", TimeHours = 3, Cost = 500, Resources = new List<string>{ "Сисадмин" }, Description = "Техническое совершенствование" },
//                                    new Option { Text = "Внедрять автоматизированные системы оповещения (4ч, 700₽)", TimeHours = 4, Cost = 700, Resources = new List<string>{ "ИБ-специалист" }, Description = "Ускорение реакции" }
//                                }
//                            }
                    //    }
                    //};








                default:
                    throw new ArgumentException("Вариант в разработке.");
    }
}
    }
}
