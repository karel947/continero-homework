using Backend_Homework.Convertors.Enums;
using Backend_Homework.Storages.Enums;
using CommandLine;

namespace Backend_Homework.UI.Options;

public class CommandLineOptions
{

    [Option('s', "source", Required = true, HelpText = "Source location of file.")]
    public string SourceLocation { get; set; } = null!;

    [Option('d', "destination", Required = true, HelpText = "Destination location of file.")]
    public string DestinationLocation { get; set; } = null!;

    [Option('f', "from", Required = false, HelpText = "Input file format.")]
    public Format? FromFormat { get; set; } = null;

    [Option('t', "to", Required = false, HelpText = "Output file format. Same as from format if empty.")]
    public Format? ToFormat { get; set; } = null;

    [Option('i', "input-storage-type", Required = true, HelpText = "Input storage type.")]
    public StorageType InputStorageType { get; set; }

    [Option('o', "output-storage-type", Required = true, HelpText = "Output storage type.")]
    public StorageType OutputStorageType { get; set; }
}