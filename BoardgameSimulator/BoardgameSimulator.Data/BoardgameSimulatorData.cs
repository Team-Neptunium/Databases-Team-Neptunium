namespace BoardgameSimulator.Data
{
    using System;
    using System.Collections.Generic;
    using Repositories;
    using Models;

    public class BoardgameSimulatorData : IBoardgameSimulatorData
    {
        private IBoardgameSimulatorDbContext context;
        private IDictionary<Type, object> repositories;

        public BoardgameSimulatorData(IBoardgameSimulatorDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public BoardgameSimulatorData()
            : this(new BoardgameSimulatorDbContext())
        {
        }

        public IGenericRepository<Army> Armies
        {
            get
            { return this.GetRepository<Army>(); }
        }

        public IGenericRepository<Skill> Skills
        {
            get
            { return this.GetRepository<Skill>(); }
        }

        public IGenericRepository<Unit> Units
        {
            get
            { return this.GetRepository<Unit>(); }
        }

        public IGenericRepository<Hero> Heroes
        {
            get { return this.GetRepository<Hero>(); }
        }

        public IGenericRepository<Item> Items
        {
            get { return this.GetRepository<Item>(); }
        }

        public IGenericRepository<AlignmentPerk> AlignmentPerks
        {
            get { return this.GetRepository<AlignmentPerk>(); }
        }

        public IGenericRepository<BattleLog> BattleLogs
        {
            get { return this.GetRepository<BattleLog>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
