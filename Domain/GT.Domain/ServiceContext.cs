using GT.Domain.Repositories;
using GT.Domain.Repositories.Interfaces;

namespace GT.Domain
{
    /// <summary>
    /// Class ServiceContext. This class cannot be inherited.
    /// </summary>
    public sealed class ServiceContext
    {
        private static readonly object _lock = new object();
        private static volatile ServiceContext _instance;
        /// <summary>
        /// The context
        /// </summary>
        private readonly GardenTrackerAppContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>Prevent direct instantiation.</remarks>
        private ServiceContext()
        {
        }

        /// <summary>
        /// Returns a single instance of the ServiceContext.
        /// </summary>
        /// <value>The instance.</value>
        /// <remarks>Singleton constructor. Creates a new static instance if one does not exist.</remarks>
        public static ServiceContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ServiceContext();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Get an instance of the CropRepository.
        /// </summary>
        /// <returns>ICropRepository.</returns>
        public static ICropRepository CropRepository(GardenTrackerAppContext context)
        {
            return new CropRepository(context);
        }

        /// <summary>
        /// Get an instance of the GardenRepository.
        /// </summary>
        /// <returns>IGardenRepository.</returns>
        public static IGardenRepository GardenRepository(GardenTrackerAppContext context)
        {
            return new GardenRepository(context);
        }

    }
}
