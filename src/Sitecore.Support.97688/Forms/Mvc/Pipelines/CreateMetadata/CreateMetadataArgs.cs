namespace Sitecore.Support.Forms.Mvc.Pipelines.CreateMetadata
{
  using Sitecore.Pipelines;
  using System;
  using System.Collections.Concurrent;
  using System.Collections.Generic;

  public class CreateMetadataArgs : PipelineArgs
  {
    public CreateMetadataArgs(System.Web.Mvc.ModelMetadata metadata, IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName, ConcurrentDictionary<string, object> data)
    {
      this.Metadata = metadata;
      this.Attributes = attributes;
      this.ContainerType = containerType;
      this.ModelAccessor = modelAccessor;
      this.ModelType = modelType;
      this.PropertyName = propertyName;
      this.SharedData = data;
    }

    public IEnumerable<Attribute> Attributes { get; private set; }

    public Type ContainerType { get; private set; }

    public System.Web.Mvc.ModelMetadata Metadata { get; private set; }

    public Func<object> ModelAccessor { get; private set; }

    public Type ModelType { get; private set; }

    public string PropertyName { get; private set; }

    public ConcurrentDictionary<string, object> SharedData { get; private set; }
  }
}