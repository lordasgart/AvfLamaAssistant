public class LlamaResponse
{
    public string model { get; set; }
    public DateTime created_at { get; set; }
    public string response { get; set; }
    public bool done { get; set; }

    // Optional fields for full response
    public string done_reason { get; set; }
    public List<int> context { get; set; }
    public long total_duration { get; set; }
    public long load_duration { get; set; }
    public int prompt_eval_count { get; set; }
    public long prompt_eval_duration { get; set; }
    public int eval_count { get; set; }
    public long eval_duration { get; set; }
}
