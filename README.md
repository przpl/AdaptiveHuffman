# AdaptiveHuffman

Adaptive Huffman Encoder and Decoder written in C#.

## Usage

Create instance:
```cs
var tree = new HuffTree();
```

Encode:
```cs
string encoded = tree.Encode(text);
```

Decode:
```cs
tree.Reset(); // reset tree before decoding. It will be automatically rebuilt
string decoded = tree.Decode(encoded);
```
