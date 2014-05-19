namespace NServiceBus
{
    using NHibernate;
    using Persistence;
// ReSharper disable RedundantNameQualifier
    using global::NHibernate.Cfg;
// ReSharper restore RedundantNameQualifier

    /// <summary>
    /// Configuration extensions for the NHibernate Timeouts persister
    /// </summary>
    public static class ConfigureNHibernateTimeoutPersister
    {
        /// <summary>
        /// Configures NHibernate Timeout Persister.
        /// </summary>
        /// <remarks>
        /// Reads configuration settings from <a href="http://msdn.microsoft.com/en-us/library/ms228154.aspx">&lt;appSettings&gt; config section</a> and <a href="http://msdn.microsoft.com/en-us/library/bf7sd233">&lt;connectionStrings&gt; config section</a>.
        /// </remarks>
        /// <example>
        /// An example that shows the minimum configuration:
        /// <code lang="XML" escaped="true">
        ///  <appSettings>
        ///    <!-- other optional settings examples -->
        ///    <add key="NServiceBus/Persistence/NHibernate/connection.provider" value="NHibernate.Connection.DriverConnectionProvider"/>
        ///    <add key="NServiceBus/Persistence/NHibernate/connection.driver_class" value="NHibernate.Driver.Sql2008ClientDriver"/>
        ///    <!-- For more setting see http://www.nhforge.org/doc/nh/en/#configuration-hibernatejdbc and http://www.nhforge.org/doc/nh/en/#configuration-optional -->
        ///  </appSettings>
        ///  
        ///  <connectionStrings>
        ///    <!-- Default connection string for all persisters -->
        ///    <add name="NServiceBus/Persistence/NHibernate" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=nservicebus;Integrated Security=True" />
        ///    
        ///    <!-- Optional overrides per persister -->
        ///    <add name="NServiceBus/Persistence/NHibernate/Timeout" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=timeout;Integrated Security=True" />
        ///  </connectionStrings>
        /// </code>
        /// </example>
        /// <param name="config">The configuration object.</param>
        /// <returns>The configuration object.</returns>

        [ObsoleteEx(RemoveInVersion = "6", TreatAsErrorFromVersion = "5.1", Replacement = "config.UsePersistence<Persistence.NHibernate>()")]
        public static Configure UseNHibernateTimeoutPersister(this Configure config)
        {
            return config.UsePersistence<Persistence.NHibernate>();
        }

        /// <summary>
        /// Configures the storage with the user supplied persistence configuration.
        /// Database schema is updated if requested by the user.
        /// </summary>
        /// <param name="config">The configuration object.</param>
        /// <param name="configuration">The <see cref="Configuration"/> object.</param>
        /// <param name="autoUpdateSchema"><value>true</value> to auto update schema</param>
        /// <returns>The configuration object</returns>
        [ObsoleteEx(RemoveInVersion = "6", TreatAsErrorFromVersion = "5.1", Replacement = "config.UsePersistence<Persistence.NHibernate>(c =>{c.UseTimeoutStorageConfiguration(configuration);if (!autoUpdateSchema){c.DisableTimeoutStorageSchemaUpdate();}});")]
        public static Configure UseNHibernateTimeoutPersister(this Configure config, Configuration configuration, bool autoUpdateSchema)
        {
            return config.UsePersistence<Persistence.NHibernate>(c =>
            {
                c.UseTimeoutStorageConfiguration(configuration);
                if (!autoUpdateSchema)
                {
                    c.DisableTimeoutStorageSchemaUpdate();   
                }
            });
        }

        /// <summary>
        /// Disables the automatic creation of the database schema.
        /// </summary>
        /// <param name="config">The configuration object.</param>
        /// <returns>The configuration object.</returns>
        [ObsoleteEx(RemoveInVersion = "6", TreatAsErrorFromVersion = "5.1", Replacement = "config.UsePersistence<Persistence.NHibernate>(c=>c.DisableTimeoutStorageSchemaUpdate())")]
        public static Configure DisableNHibernateTimeoutPersisterInstall(this Configure config)
        {
            return config.UsePersistence<Persistence.NHibernate>(c=>c.DisableTimeoutStorageSchemaUpdate());
        }
    }
}