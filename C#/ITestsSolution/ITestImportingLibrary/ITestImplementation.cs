using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Contracts;

namespace CommonTypes
{
    /// <summary>
    /// Экспортируемый средствами MEF интерфейс.
    /// Он же должен реализовывать интерфейсы ITest* (все или часть, которую осилил соискатель).
    /// Если возникла сложность реализации каких-то отдельных методов интерфейсов ITest*, 
    /// эти методы должны порождать исключение NotImplementedException
    /// </summary>

    public class Importer
    {
        [ImportMany]
        private IEnumerable<Lazy<IComponent, IMetadata>> operations;

        public void DoImport()
        {
            //Общий каталог, объединяющий несколько каталогов
            var catalog = new AggregateCatalog();

            //Добавляет все части, найденные во всех assemblies 
            //в тот же каталог, что и исполняемая программа
            catalog.Catalogs.Add(
                new DirectoryCatalog(
                    Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location
                    )
                )
            );

            //Создаём CompositionContainer со всеми частями каталога
            CompositionContainer container = new CompositionContainer(catalog);

            //Заполняем импорты объекта
            container.ComposeParts(this);
        }

        public int DoneNumberOfTests
        {
            get { return operations != null ? operations.Count() : 0; }
        }
    }
    public interface ITestImplementation
    {
        /// <summary>
        /// ФИО соискателя, выполнившего тестовое задание
        /// </summary>
        string AuthorName { get; }
    }
}
