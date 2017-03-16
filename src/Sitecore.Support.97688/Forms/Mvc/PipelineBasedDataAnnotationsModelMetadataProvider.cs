namespace Sitecore.Support.Forms.Mvc
{
  using System;
  using System.Collections.Generic;
  using Sitecore.Pipelines;
  using DataAnnotationsModelMetadataProvider = System.Web.Mvc.DataAnnotationsModelMetadataProvider;
  using ModelMetadata = System.Web.Mvc.ModelMetadata;
  using System.Collections.Concurrent;

  public class PipelineBasedDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
  {
    protected ConcurrentDictionary<string, object> Data = new ConcurrentDictionary<string, object>();

    protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
    {
      var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
      var args = new Pipelines.CreateMetadata.CreateMetadataArgs(metadata, attributes, containerType, modelAccessor, modelType, propertyName, this.Data);
      CorePipeline.Run("wffm.createMetadata", args);
      return metadata;
    }
  }
}
