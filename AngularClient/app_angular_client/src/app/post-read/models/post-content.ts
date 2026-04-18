import { ModerationResult } from "../../media-core/moderation-result";

export interface PostContent{
  value: string;
  moderationResult? : ModerationResult;
}
