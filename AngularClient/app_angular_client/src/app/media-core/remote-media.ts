import { Dimension } from "./dimension";
import { BaseMedia } from "./base-media";
import { MediaType } from "./media-type";

export class RemoteMedia extends BaseMedia{
  containerName: string;
  blobName: string;
  dimension: Dimension;

  constructor(
    containerName: string,
    blobName: string,
    type: MediaType,
    dimension: Dimension,
  ) {
    super(type);
    this.containerName = containerName;
    this.blobName = blobName;
    this.dimension = dimension;
  }
}
