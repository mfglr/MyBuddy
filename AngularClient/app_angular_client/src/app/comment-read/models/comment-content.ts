import { ModerationResult } from "../../media-core/moderation-result";

export interface CommentContent{
  value: string;
  moderationResult?: ModerationResult
}
