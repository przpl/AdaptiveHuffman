using Huffman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HuffmanTests
{
    [TestClass]
    public class HuffTreeTests
    {
        [TestMethod]
        public void Constructor_InitializesTree_Initialized()
        {
            var tree = new HuffTree();
            
            Assert.AreEqual(512, tree.Root.Number);
            Assert.AreEqual(0, tree.Root.Weight);
            Assert.IsNull(tree.Root.Right);
            Assert.IsNull(tree.Root.Left);
        }

        [TestMethod]
        public void Encode_AddsZeroSymbol_Added()
        {
            var tree = new HuffTree();
            tree.Encode('z');

            Assert.AreEqual(512, tree.Root.Number);
            Assert.AreEqual(1, tree.Root.Weight);
            Assert.AreEqual(511, tree.Root.Right.Number);
            Assert.AreEqual(1, tree.Root.Right.Weight);
            Assert.AreEqual('z', tree.Root.Right.Symbol);
            Assert.AreEqual(510, tree.Root.Left.Number);
            Assert.AreEqual(0, tree.Root.Left.Weight);
        }

        [TestMethod]
        public void Encode_AddsTwoOneSymbols_Added()
        {
            var tree = new HuffTree();
            tree.Encode('a');
            tree.Encode('a');

            Assert.AreEqual(512, tree.Root.Number);
            Assert.AreEqual(2, tree.Root.Weight);
            Assert.AreEqual(511, tree.Root.Right.Number);
            Assert.AreEqual(2, tree.Root.Right.Weight);
            Assert.AreEqual('a', tree.Root.Right.Symbol);
            Assert.AreEqual(510, tree.Root.Left.Number);
            Assert.AreEqual(0, tree.Root.Left.Weight);
        }

        [TestMethod]
        public void Encode_AddsTwoSymbol_Added()
        {
            var tree = new HuffTree();
            tree.Encode('a');
            tree.Encode('a');
            tree.Encode('b');

            var r = tree.Root;
            Assert.AreEqual(512, r.Number);
            Assert.AreEqual(3, r.Weight);
            Assert.AreEqual(511, r.Right.Number);
            Assert.AreEqual(2, r.Right.Weight);
            Assert.AreEqual('a', r.Right.Symbol);
            Assert.AreEqual(510, r.Left.Number);
            Assert.AreEqual(1, r.Left.Weight);
            var n510 = r.Left;
            Assert.AreEqual(509, n510.Right.Number);
            Assert.AreEqual(1, n510.Right.Weight);
            Assert.AreEqual('b', n510.Right.Symbol);
            Assert.AreEqual(508, n510.Left.Number);
            Assert.AreEqual(0, n510.Left.Weight);
        }

        [TestMethod]
        public void Encode_AddsThreeSymbol_Added()
        {
            var tree = new HuffTree();
            tree.Encode('a');
            tree.Encode('a');
            tree.Encode('b');
            tree.Encode('r');

            var r = tree.Root;
            Assert.AreEqual(512, r.Number);
            Assert.AreEqual(4, r.Weight);
            Assert.AreEqual(511, r.Right.Number);
            Assert.AreEqual(2, r.Right.Weight);
            Assert.AreEqual('a', r.Right.Symbol);
            Assert.AreEqual(510, r.Left.Number);
            Assert.AreEqual(2, r.Left.Weight);
            var n510 = r.Left;
            Assert.AreEqual(509, n510.Right.Number);
            Assert.AreEqual(1, n510.Right.Weight);
            Assert.AreEqual('b', n510.Right.Symbol);
            Assert.AreEqual(508, n510.Left.Number);
            Assert.AreEqual(1, n510.Left.Weight);
            var n508 = n510.Left;
            Assert.AreEqual(507, n508.Right.Number);
            Assert.AreEqual(1, n508.Right.Weight);
            Assert.AreEqual('r', n508.Right.Symbol);
            Assert.AreEqual(506, n508.Left.Number);
            Assert.AreEqual(0, n508.Left.Weight);
        }

        [TestMethod]
        public void Encode_AddsFourSymbol_Added()
        {
            var tree = new HuffTree();
            tree.Encode('a');
            tree.Encode('a');
            tree.Encode('b');
            tree.Encode('r');
            tree.Encode('d');

            var r = tree.Root;
            Assert.AreEqual(512, r.Number);
            Assert.AreEqual(5, r.Weight);
            Assert.AreEqual(511, r.Right.Number);
            Assert.AreEqual(3, r.Right.Weight);
            Assert.AreEqual(510, r.Left.Number);
            Assert.AreEqual(2, r.Left.Weight);
            Assert.AreEqual('a', r.Left.Symbol);
            var n511 = r.Right;
            Assert.AreEqual(509, n511.Right.Number);
            Assert.AreEqual(2, n511.Right.Weight);
            Assert.AreEqual(508, n511.Left.Number);
            Assert.AreEqual(1, n511.Left.Weight);
            Assert.AreEqual('b', n511.Left.Symbol);
            var n509 = n511.Right;
            Assert.AreEqual(507, n509.Right.Number);
            Assert.AreEqual(1, n509.Right.Weight);
            Assert.AreEqual('r', n509.Right.Symbol);
            Assert.AreEqual(506, n509.Left.Number);
            Assert.AreEqual(1, n509.Left.Weight);
            var n506 = n509.Left;
            Assert.AreEqual(505, n506.Right.Number);
            Assert.AreEqual(1, n506.Right.Weight);
            Assert.AreEqual('d', n506.Right.Symbol);
            Assert.AreEqual(504, n506.Left.Number);
            Assert.AreEqual(0, n506.Left.Weight);
        }

        [TestMethod]
        public void Encode_AddsOneSymbol_CodeReturned()
        {
            var tree = new HuffTree();

            Assert.AreEqual("a", tree.Encode('a'));
        }

        [TestMethod]
        public void Encode_AddsTwoOneSymbols_CodeReturned()
        {
            var tree = new HuffTree();

            Assert.AreEqual("a", tree.Encode('a'));
            Assert.AreEqual("1", tree.Encode('a'));
        }

        [TestMethod]
        public void Encode_AddsTwoSymbol_CodeReturned()
        {
            var tree = new HuffTree();

            Assert.AreEqual("a", tree.Encode('a'));
            Assert.AreEqual("1", tree.Encode('a'));
            Assert.AreEqual("0b", tree.Encode('b'));
        }

        [TestMethod]
        public void Encode_AddsThreeSymbol_CodeReturned()
        {
            var tree = new HuffTree();

            Assert.AreEqual("a", tree.Encode('a'));
            Assert.AreEqual("1", tree.Encode('a'));
            Assert.AreEqual("0b", tree.Encode('b'));
            Assert.AreEqual("00r", tree.Encode('r'));
        }

        [TestMethod]
        public void Encode_AddsFourSymbol_CodeReturned()
        {
            var tree = new HuffTree();

            Assert.AreEqual("a", tree.Encode('a'));
            Assert.AreEqual("1", tree.Encode('a'));
            Assert.AreEqual("0b", tree.Encode('b'));
            Assert.AreEqual("00r", tree.Encode('r'));
            Assert.AreEqual("000d", tree.Encode('d'));
        }

        [TestMethod]
        public void Encode_EncodesText_Encoded()
        {
            var tree = new HuffTree();
            var result = tree.Encode("This is short sample text to encode.");

            Assert.AreEqual("T0h00i100s000 011111101111110100o1000r0000t1010111000a101100m111000p00100l00000e101000011010111000x1000101110011010111011101100n1011100c10110010000d0111100100.", result);
        }

        [TestMethod]
        public void Decode_DecodesFiveCodes_Decoded()
        {
            var tree = new HuffTree();

            Assert.AreEqual("a", tree.Decode("a"));
            Assert.AreEqual("a", tree.Decode("1"));
            Assert.AreEqual("b", tree.Decode("0b"));
            Assert.AreEqual("r", tree.Decode("00r"));
            Assert.AreEqual("d", tree.Decode("000d"));
        }

        [TestMethod]
        public void Decode_DecodesText_Decoded()
        {
            var tree = new HuffTree();
            var result = tree.Decode("T0h00i100s000 011111101111110100o1000r0000t1010111000a101100m111000p00100l00000e101000011010111000x1000101110011010111011101100n1011100c10110010000d0111100100.");

            Assert.AreEqual("This is short sample text to encode.", result);
        }
    }
}