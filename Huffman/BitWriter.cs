using System.IO;

namespace Huffman
{
    public class BitWriter
    {
        private int _bitsCount;
        private readonly Stream _stream;
        private byte _current;

        public BitWriter(Stream stream)
        {
            _stream = stream;
        }

        public void Write(string bits)
        {
            foreach (var bit in bits)
            {
                if (bit == '0')
                    Write(false);
                if (bit == '1')
                    Write(true);
            }
        }

        public void Write(bool bit)
        {
            _current *= 2;
            if (bit)
                _current++;
            _bitsCount++;

            if (_bitsCount == 8)
            {
                _stream.WriteByte(_current);
                _current = 0;
                _bitsCount = 0;
            }
        }

        public void Flush()
        {
            if (_bitsCount == 0)
                return;

            while (_bitsCount < 8)
            {
                _current *= 2;
                _bitsCount++;
            }

            _stream.WriteByte(_current);
        }
    }
}
