namespace Sitecore.Support.Forms.Mvc.Pipelines.CreateMetadata
{
  using Diagnostics;
  using Sitecore.Forms.Mvc;
  using Sitecore.Forms.Mvc.Interfaces;

  public class AddWffmMetadata
  {
    public string ContainerKey = "wffm.AdditionalMetadataValueKey";

    public virtual void Process(CreateMetadataArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      if (typeof(IContainerMetadata).IsAssignableFrom(args.ModelType))
      {
        object obj2;
        args.SharedData.TryRemove(this.ContainerKey, out obj2);
        args.SharedData.TryAdd(this.ContainerKey, args.ModelAccessor?.Invoke());
      }
      if (typeof(IContainerMetadata).IsAssignableFrom(args.ContainerType) && args.SharedData.ContainsKey(this.ContainerKey))
      {
        args.Metadata.AdditionalValues.Add(Constants.Container, args.SharedData[this.ContainerKey]);
      }
    }
  }
}
