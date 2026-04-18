import { MediaType } from "./media-type";
import { Metadata } from "./metadata";
import { ModerationResult } from "./moderation-result";
import { Thumbnail } from "./thumbnail";
import { Transcoding } from "./transcoding";

export interface Media{
  containerName: string;
  blobName: string;
  type: MediaType;
  metadata: Metadata;
  moderationResult?: ModerationResult;
  thumbnails: Array<Thumbnail>;
  transcodings: Array<Transcoding>;
}
