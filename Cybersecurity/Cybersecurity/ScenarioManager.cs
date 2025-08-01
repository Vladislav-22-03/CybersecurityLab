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
                        StartTime = new DateTime(2025, 7, 25, 10, 0, 0),
                        Steps = new List<Step>
                        {
                            new Step
                            {
                                Question = "Как вы поступите с подозрительным трафиком?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Перезагрузить сервер", TimeHours = 4, Cost = 500, Resources = new List<string> { "Сисадмин" }, Description = "Сброс работы сервера без анализа угрозы" },
                                    new Option { Text = "Изолировать и провести анализ", TimeHours = 16, Cost = 1200, Resources = new List<string> { "ИБ-специалист", "Сканер" }, Description = "Отключение от сети и анализ источника угрозы" },
                                    new Option { Text = "Проигнорировать", TimeHours = 2, Cost = 0, Resources = new List<string>(), Consequence = "Утечка данных", Description = "Игнорирование подозрительного трафика без действий" },
                                    new Option { Text = "Сообщить начальству", TimeHours = 10, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Уведомление руководства о возможной атаке" }
                                }
                            },
                            new Step
                            {
                                Question = "Что использовать для анализа?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Wireshark (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "ИБ-специалист" }, Description = "Использование сетевого анализатора Wireshark для изучения трафика" },
                                    new Option { Text = "Firewall-логи (1ч, 0₽)", TimeHours = 1, Cost = 0, Resources = new List<string>(), Description = "Анализ логов межсетевого экрана" },
                                    new Option { Text = "Антивирусный сканер (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Сканер" }, Description = "Проверка на вредоносное ПО антивирусным сканером" },
                                    new Option { Text = "Внешний сервис (4ч, 1000₽)", TimeHours = 4, Cost = 1000, Resources = new List<string> { "Поставщик" }, Description = "Передача данных на анализ стороннему сервису" }
                                }
                            },
                            new Step
                            {
                                Question = "Кто будет заниматься решением проблемы?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Внутренний ИБ-специалист (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "ИБ-специалист" }, Description = "Поручение задачи штатному специалисту по безопасности" },
                                    new Option { Text = "Вся команда (1ч, 3000₽)", TimeHours = 1, Cost = 3000, Resources = new List<string> { "Все" }, Description = "Мобилизация всей команды на устранение проблемы" },
                                    new Option { Text = "Стажер (6ч, 100₽)", TimeHours = 6, Cost = 100, Resources = new List<string> { "Стажер" }, Consequence = "Риск ошибки", Description = "Передача задачи стажеру с минимальным опытом" },
                                    new Option { Text = "Аутсорс (2ч, 2000₽)", TimeHours = 2, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Привлечение внешней компании для решения инцидента" }
                                }
                            },
                            new Step
                            {
                                Question = "Нужна ли проверка системы после устранения?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Да, провести сканирование (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "Сканер" }, Description = "Полная проверка всей системы после устранения" },
                                    new Option { Text = "Только внешние порты (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string>(), Description = "Ограниченная проверка только входящих соединений" },
                                    new Option { Text = "Нет, всё в порядке (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Description = "Отказ от проверки — считаем, что проблема решена" },
                                    new Option { Text = "Отложим до понедельника (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Проблема может повториться", Description = "Перенос проверки на будущее, без текущих действий" }
                                }
                            },
                            new Step
                            {
                                Question = "Хотите подготовить отчет?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Да, полный отчёт (3ч, 1000₽)", TimeHours = 3, Cost = 1000, Resources = new List<string> { "Менеджер" }, Description = "Создание подробного документа об инциденте и действиях" },
                                    new Option { Text = "Краткий отчёт (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Стажер" }, Description = "Минимальное фиксирование информации об инциденте" },
                                    new Option { Text = "Не нужен (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Description = "Отказ от создания отчета" },
                                    new Option { Text = "Сделать через ИИ (1ч, 150₽)", TimeHours = 1, Cost = 150, Resources = new List<string> { "GPT :)" }, Description = "Формирование отчета с помощью искусственного интеллекта" }
                                }
                            },
                            new Step
                            {
                                Question = "Нужно ли уведомить клиентов о возможной утечке?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Да, сразу сообщить (2ч, 200₽)", TimeHours = 2, Cost = 200, Resources = new List<string> { "Менеджер" }, Description = "Прозрачность в отношениях с клиентами, снижение репутационных рисков" },
                                    new Option { Text = "Только ключевых клиентов (1ч, 100₽)", TimeHours = 1, Cost = 100, Resources = new List<string> { "Менеджер" }, Description = "Избирательное уведомление наиболее важных клиентов" },
                                    new Option { Text = "Подождать результатов анализа (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Клиенты могут узнать сами", Description = "Риск потери доверия при утечке информации" },
                                    new Option { Text = "Не сообщать (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Репутационные потери", Description = "Попытка скрыть инцидент" }
                                }
                            },
                            new Step
                            {
                                Question = "Как укрепить защиту на будущее?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Внедрить IDS/IPS (5ч, 3000₽)", TimeHours = 5, Cost = 3000, Resources = new List<string> { "Сисадмин", "ИБ-специалист" }, Description = "Системы обнаружения и предотвращения атак" },
                                    new Option { Text = "Обновить политики безопасности (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Менеджер", "ИБ-специалист" }, Description = "Обновление регламентов и инструкций" },
                                    new Option { Text = "Провести тренинг (3ч, 1500₽)", TimeHours = 3, Cost = 1500, Resources = new List<string> { "Менеджер" }, Description = "Обучение сотрудников правилам ИБ" },
                                    new Option { Text = "Ничего не менять (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Риск повторения", Description = "Отказ от мер по усилению защиты" }
                                }
                            },
                            new Step
                            {
                                Question = "Кто будет контролировать ситуацию в течение недели?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Назначить ответственного (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Выделение человека для мониторинга состояния" },
                                    new Option { Text = "Использовать автоматический мониторинг (2ч, 600₽)", TimeHours = 2, Cost = 600, Resources = new List<string> { "Сканер" }, Description = "Настройка автоматических уведомлений и логирования" },
                                    new Option { Text = "Передать контроль на аутсорс (1ч, 1000₽)", TimeHours = 1, Cost = 1000, Resources = new List<string> { "Подрядчик" }, Description = "Использование услуг внешней ИБ-компании" },
                                    new Option { Text = "Никто не будет контролировать (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Угрозы останутся незамеченными", Description = "Игнорирование постинцидентного мониторинга" }
                                }
                            },
                            new Step
                            {
                                Question = "Следует ли инициировать внутренний аудит ИБ?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Да, срочный аудит (4ч, 2500₽)", TimeHours = 4, Cost = 2500, Resources = new List<string> { "ИБ-специалист", "Менеджер" }, Description = "Полная проверка текущего состояния безопасности" },
                                    new Option { Text = "Плановый аудит позже (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Description = "Аудит будет проведён в будущем согласно графику" },
                                    new Option { Text = "Поручить внешний аудит (3ч, 4000₽)", TimeHours = 3, Cost = 4000, Resources = new List<string> { "Подрядчик" }, Description = "Независимая оценка уровня защищенности" },
                                    new Option { Text = "Не проводить аудит (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Могут остаться уязвимости", Description = "Отказ от анализа текущих слабых мест" }
                                }
                            },
                            new Step
                            {
                                Question = "Каким образом хранить артефакты инцидента?",
                                Options = new List<Option>
                                {
                                    new Option { Text = "Сохранить в зашифрованном архиве (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "ИБ-специалист" }, Description = "Безопасное хранение данных для возможного расследования" },
                                    new Option { Text = "Отправить в CERT (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Менеджер" }, Description = "Передача материалов в национальный центр реагирования" },
                                    new Option { Text = "Удалить после отчёта (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Невозможность последующего анализа", Description = "Удаление после завершения расследования" },
                                    new Option { Text = "Хранить на сервере без защиты (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Риск компрометации", Description = "Небезопасное хранение артефактов инцидента" }
                                }
                            },

                        }
                    };
                case 1:
                    return new Scenario
                    {
                        VariantId = 1,
                        Incident = "Обнаружено несанкционированное подключение к сети.",
                        StartTime = new DateTime(2025, 7, 25, 10, 0, 0),
                        Steps = new List<Step>
                            {
                                new Step
                                {
                                    Question = "Что делать с несанкционированным подключением?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Отключить устройство немедленно", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой администратор" }, Description = "Физическое или программное отключение неизвестного устройства" },
                                        new Option { Text = "Провести расследование", TimeHours = 10, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Детальное изучение инцидента и возможных последствий" },
                                        new Option { Text = "Игнорировать, если не мешает", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Риск утечки данных", Description = "Не предпринимать действий, если устройство не влияет на работу" },
                                        new Option { Text = "Сообщить руководство", TimeHours = 2, Cost = 300, Resources = new List<string> { "Менеджер" }, Description = "Передать информацию руководству для дальнейших решений" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Какое оборудование использовать для блокировки?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Аппаратный файрволл (3ч, 700₽)", TimeHours = 3, Cost = 700, Resources = new List<string> { "Сетевой администратор" }, Description = "Использование физического устройства для фильтрации трафика" },
                                        new Option { Text = "Программный фильтр (2ч, 300₽)", TimeHours = 2, Cost = 300, Resources = new List<string> { "Системный администратор" }, Description = "Настройка программных правил блокировки подключения" },
                                        new Option { Text = "VPN-сегментация (5ч, 1500₽)", TimeHours = 5, Cost = 1500, Resources = new List<string> { "ИБ-специалист" }, Description = "Разделение сетей с помощью VPN для изоляции угроз" },
                                        new Option { Text = "Аутсорсинг защиты (4ч, 2000₽)", TimeHours = 4, Cost = 2000, Resources = new List<string> { "Подрядчик" }, Description = "Привлечение сторонней компании для настройки блокировок" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Кто будет контролировать ситуацию?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Ответственный администратор (4ч, 1000₽)", TimeHours = 4, Cost = 1000, Resources = new List<string> { "Администратор" }, Description = "Назначение одного администратора для наблюдения" },
                                        new Option { Text = "Команда ИБ (2ч, 2500₽)", TimeHours = 2, Cost = 2500, Resources = new List<string> { "Все" }, Description = "Совместный контроль специалистами по информационной безопасности" },
                                        new Option { Text = "Стажер (6ч, 150₽)", TimeHours = 6, Cost = 150, Resources = new List<string> { "Стажер" }, Consequence = "Высокий риск ошибки", Description = "Контроль за ситуацией со стороны неопытного сотрудника" },
                                        new Option { Text = "Внешняя компания (3ч, 3000₽)", TimeHours = 3, Cost = 3000, Resources = new List<string> { "Подрядчик" }, Description = "Передача контроля сторонней организации" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Проводить ли аудит безопасности после?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Полный аудит (8ч, 4000₽)", TimeHours = 8, Cost = 4000, Resources = new List<string> { "ИБ-специалист" }, Description = "Всеобъемлющая проверка всей ИТ-инфраструктуры" },
                                        new Option { Text = "Только основные службы (3ч, 1200₽)", TimeHours = 3, Cost = 1200, Resources = new List<string> { "Администратор" }, Description = "Проверка ключевых компонентов системы" },
                                        new Option { Text = "Минимальный аудит (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string>(), Description = "Быстрая базовая проверка на наличие проблем" },
                                        new Option { Text = "Не проводить (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Риск повторной атаки", Description = "Отказ от аудита после инцидента" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Подготовить отчет о происшествии?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Полный отчет (4ч, 1500₽)", TimeHours = 4, Cost = 1500, Resources = new List<string> { "Менеджер" }, Description = "Подробное документирование всех этапов инцидента" },
                                        new Option { Text = "Краткий отчет (2ч, 700₽)", TimeHours = 2, Cost = 700, Resources = new List<string> { "Стажер" }, Description = "Краткое описание сути и решения инцидента" },
                                        new Option { Text = "Отказаться от отчета (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Description = "Не составлять документ по результатам инцидента" },
                                        new Option { Text = "Сделать с помощью ИИ (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "GPT :)" }, Description = "Автоматическая генерация отчета нейросетью" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Следует ли уведомить руководство о результатах расследования?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Да, с подробностями (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Менеджер" }, Description = "Информирование руководства с анализом последствий и рекомендациями" },
                                        new Option { Text = "Краткое уведомление (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Стажер" }, Description = "Минимальный отчёт без технических деталей" },
                                        new Option { Text = "Сообщить только при повторении инцидента (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Руководство может быть неготово", Description = "Задержка в коммуникации может создать риски" },
                                        new Option { Text = "Не сообщать (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Нарушение внутреннего регламента", Description = "Утаивание инцидента от руководства" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Нужно ли информировать сотрудников?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Да, провести инструктаж (2ч, 1000₽)", TimeHours = 2, Cost = 1000, Resources = new List<string> { "Менеджер", "ИБ-специалист" }, Description = "Повышение осведомленности среди персонала" },
                                        new Option { Text = "Отправить памятку по почте (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Стажер" }, Description = "Рассылка информационных рекомендаций" },
                                        new Option { Text = "Обучение только ИТ-персонала (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Сисадмин" }, Description = "Углублённое обучение технических сотрудников" },
                                        new Option { Text = "Не информировать (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Сотрудники могут повторно подключать неразрешённые устройства", Description = "Риск несанкционированных действий в будущем" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Что делать с логами событий?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Сохранить и архивировать (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "ИБ-специалист" }, Description = "Хранение логов для последующего анализа" },
                                        new Option { Text = "Передать внешним экспертам (2ч, 800₽)", TimeHours = 2, Cost = 800, Resources = new List<string> { "Подрядчик" }, Description = "Отправка логов на внешний аудит" },
                                        new Option { Text = "Удалить после анализа (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Утеря доказательств", Description = "Лишение возможности провести повторную экспертизу" },
                                        new Option { Text = "Оставить без изменений (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Нарушение требований хранения", Description = "Несоблюдение регламентов по логированию" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Стоит ли внедрить систему контроля доступа к сети?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Да, NAC-система (5ч, 3000₽)", TimeHours = 5, Cost = 3000, Resources = new List<string> { "ИБ-специалист", "Сетевой администратор" }, Description = "Настройка системы контроля доступа к сети (Network Access Control)" },
                                        new Option { Text = "Только MAC-фильтрация (2ч, 500₽)", TimeHours = 2, Cost = 500, Resources = new List<string> { "Сетевой администратор" }, Description = "Ограничение доступа по MAC-адресам" },
                                        new Option { Text = "Ограничить доступ через DHCP (1ч, 300₽)", TimeHours = 1, Cost = 300, Resources = new List<string> { "Сисадмин" }, Description = "Фильтрация клиентов по IP и разрешениям DHCP" },
                                        new Option { Text = "Не внедрять (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Уязвимость к новым подключениям", Description = "Отсутствие дополнительных мер доступа" }
                                    }
                                },
                                new Step
                                {
                                    Question = "Как действовать в случае повторного подключения?",
                                    Options = new List<Option>
                                    {
                                        new Option { Text = "Блокировать по MAC-адресу (1ч, 200₽)", TimeHours = 1, Cost = 200, Resources = new List<string> { "Сетевой администратор" }, Description = "Быстрое отключение конкретного устройства по его адресу" },
                                        new Option { Text = "Отслеживать и записывать активность (3ч, 800₽)", TimeHours = 3, Cost = 800, Resources = new List<string> { "ИБ-специалист" }, Description = "Мониторинг действий для последующего расследования" },
                                        new Option { Text = "Сообщить в правоохранительные органы (5ч, 0₽)", TimeHours = 5, Cost = 0, Resources = new List<string> { "Менеджер" }, Description = "Официальное реагирование на инцидент внешними структурами" },
                                        new Option { Text = "Не реагировать (0ч, 0₽)", TimeHours = 0, Cost = 0, Resources = new List<string>(), Consequence = "Повторный взлом возможен", Description = "Игнорирование угрозы" }
                                    }
                                }

                            }
                    };
                default:
                    throw new ArgumentException("Вариант в разработке.");
            }
        }
    }
}
