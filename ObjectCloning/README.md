# Object Cloning Performance Benchmarks

This project compares the performance of different deep cloning methods for objects in C#:

1. **Newtonsoft.Json Serialization** - Using Newtonsoft.Json to serialize an object to JSON and then deserialize it back
2. **System.Text.Json Serialization** - Using the built-in System.Text.Json to serialize and deserialize objects
3. **Protobuf Serialization** - Using protobuf-net for binary serialization and deserialization
4. **Manual Property Copying** - Explicitly copying each property to create a new object

## Project Structure

- **Models/** - Contains the object models used for benchmarking with Protobuf attributes
- **Cloners/** - Contains the implementation of different cloning methods
- **Benchmarks/** - Contains the BenchmarkDotNet benchmark classes

## Running the Benchmarks

To run the benchmarks:

```bash
cd ObjectCloning
dotnet run -c Release
```

To run validation tests to verify the cloning methods work correctly:

```bash
cd ObjectCloning
dotnet run -c Release test
```

## Benchmark Parameters

The benchmarks test all cloning methods with:

- **Simple Object** - A Person object with minimal nested data
- **Complex Object** - A Person object with multiple nested objects, collections, and dictionaries

## Results

The benchmark results will show:

- **Mean** - Average execution time
- **Error** - Half of 99.9% confidence interval
- **StdDev** - Standard deviation of measurements
- **Median** - Value separating the higher half from the lower half of measurements
- **Rank** - Relative performance ranking (1 is fastest)
- **Gen 0/1/2** - GC collections in generations 0, 1, and 2
- **Allocated** - Memory allocated per operation

## Performance Comparison

Based on typical benchmarks, the performance ranking from fastest to slowest is:

1. **Manual Property Copying** - Fastest but requires custom implementation for each class
2. **Protobuf Serialization** - Fast binary serialization with compact format
3. **System.Text.Json** - Modern JSON serializer with good performance
4. **Newtonsoft.Json** - Feature-rich but slower JSON serializer

## Trade-offs

- **Manual Cloning**: Fastest performance but high maintenance cost and error-prone
- **Protobuf**: Good balance of performance and convenience, but requires schema definition
- **System.Text.Json**: Built-in, no extra dependencies, but less feature-rich than Newtonsoft
- **Newtonsoft.Json**: Most feature-rich but slowest performance

## Dependencies

- BenchmarkDotNet (0.14.0)
- Newtonsoft.Json (13.0.3)
- protobuf-net (3.2.52)
- System.Text.Json (built into .NET)
