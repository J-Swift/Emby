﻿using MediaBrowser.Common.IO;
using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Logging;
using MediaBrowser.Providers.Manager;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CommonIO;

namespace MediaBrowser.Providers.Games
{
    public class GameSystemMetadataService : MetadataService<GameSystem, GameSystemInfo>
    {
        public GameSystemMetadataService(IServerConfigurationManager serverConfigurationManager, ILogger logger, IProviderManager providerManager, IProviderRepository providerRepo, IFileSystem fileSystem, IUserDataManager userDataManager, ILibraryManager libraryManager) : base(serverConfigurationManager, logger, providerManager, providerRepo, fileSystem, userDataManager, libraryManager)
        {
        }

        protected override void MergeData(MetadataResult<GameSystem> source, MetadataResult<GameSystem> target, List<MetadataFields> lockedFields, bool replaceData, bool mergeMetadataSettings)
        {
            ProviderUtils.MergeBaseItemData(source, target, lockedFields, replaceData, mergeMetadataSettings);

            var sourceItem = source.Item;
            var targetItem = target.Item;

            if (replaceData || string.IsNullOrEmpty(targetItem.GameSystemName))
            {
                targetItem.GameSystemName = sourceItem.GameSystemName;
            }
        }
    }
}
