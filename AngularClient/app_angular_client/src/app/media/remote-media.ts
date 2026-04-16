import { Media } from "./media";
import { MediaType } from "./media-type";
import { Metadata } from "./metadata";
import { ModerationResult } from "./moderation-result";

export class RemoteMedia extends Media{
  containerName: string;
  blobName: string;
  metadata: Metadata;
  moderationResult?: ModerationResult;

  constructor(
    containerName: string,
    blobName: string,
    type: MediaType,
    metadata: Metadata,
    moderationResult?: ModerationResult,
  ) {
    super(type);
    this.containerName = containerName;
    this.blobName = blobName;
    this.metadata = metadata;
    this.moderationResult = moderationResult;
  }
}
