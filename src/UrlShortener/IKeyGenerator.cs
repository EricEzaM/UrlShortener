namespace UrlShortener
{
	public interface IKeyGenerator
	{
		string GetKey(int size);
	}
}