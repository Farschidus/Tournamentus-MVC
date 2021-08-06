using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Tournamentus.WebApp.Providers
{
    public class NullToEmptyStringProvider : IMetadataDetailsProvider, IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Key.MetadataKind == ModelMetadataKind.Property)
            {
                context.DisplayMetadata.ConvertEmptyStringToNull = false;
            }
        }
    }
}
