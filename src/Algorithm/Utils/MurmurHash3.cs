namespace Algorithm.Utils;
public static class MurmurHash3
{
    public static int Hash32(int input)
    {
        const uint seed = 144; // Pode ser qualquer valor
        const uint c1 = 0xcc9e2d51;
        const uint c2 = 0x1b873593;
        const uint r1 = 15;
        const uint r2 = 13;
        const uint m = 5;
        const uint n = 0xe6546b64;

        uint hash = seed;

        uint k = (uint)input;
        k *= c1;
        k = RotateLeft(k, (int)r1);
        k *= c2;

        hash ^= k;
        hash = RotateLeft(hash, (int)r2);
        hash = hash * m + n;

        hash ^= 4; // Tamanho do int (4 bytes)

        hash ^= hash >> 16;
        hash *= 0x85ebca6b;
        hash ^= hash >> 13;
        hash *= 0xc2b2ae35;
        hash ^= hash >> 16;

        return (int)hash;
    }

    private static uint RotateLeft(uint x, int r)
    {
        return (x << r) | (x >> (32 - r));
    }
}



