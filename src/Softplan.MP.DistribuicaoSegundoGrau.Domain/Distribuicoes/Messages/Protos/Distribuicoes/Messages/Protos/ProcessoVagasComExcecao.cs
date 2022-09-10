// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ProcessoVagasComExcecao.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using System.Diagnostics.CodeAnalysis;
using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos {

  [ExcludeFromCodeCoverage]
  /// <summary>Holder for reflection information generated from ProcessoVagasComExcecao.proto</summary>
  public static partial class ProcessoVagasComExcecaoReflection {

    #region Descriptor
    /// <summary>File descriptor for ProcessoVagasComExcecao.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ProcessoVagasComExcecaoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1Qcm9jZXNzb1ZhZ2FzQ29tRXhjZWNhby5wcm90byJcChdQcm9jZXNzb1Zh",
            "Z2FzQ29tRXhjZWNhbxIxCg92YWdhc19yZW1vdmlkYXMYASADKAsyGC5WYWdh",
            "c0NvbUV4Y2VjYW9SZW1vdmlkYRIOCgZtb3Rpdm8YAiABKAkiPQoXVmFnYXND",
            "b21FeGNlY2FvUmVtb3ZpZGESDwoHaWRfdmFnYRgBIAEoBRIRCglkZXNjcmlj",
            "YW8YAiABKAlCS6oCSFNvZnRwbGFuLk1QLkRpc3RyaWJ1aWNhb1NlZ3VuZG9H",
            "cmF1LkRvbWFpbi5EaXN0cmlidWljb2VzLk1lc3NhZ2VzLlByb3Rvc2IGcHJv",
            "dG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.ProcessoVagasComExcecao), global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.ProcessoVagasComExcecao.Parser, new[]{ "VagasRemovidas", "Motivo" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida), global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida.Parser, new[]{ "IdVaga", "Descricao" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ProcessoVagasComExcecao : pb::IMessage<ProcessoVagasComExcecao>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProcessoVagasComExcecao> _parser = new pb::MessageParser<ProcessoVagasComExcecao>(() => new ProcessoVagasComExcecao());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProcessoVagasComExcecao> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.ProcessoVagasComExcecaoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProcessoVagasComExcecao() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProcessoVagasComExcecao(ProcessoVagasComExcecao other) : this() {
      vagasRemovidas_ = other.vagasRemovidas_.Clone();
      motivo_ = other.motivo_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProcessoVagasComExcecao Clone() {
      return new ProcessoVagasComExcecao(this);
    }

    /// <summary>Field number for the "vagas_removidas" field.</summary>
    public const int VagasRemovidasFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida> _repeated_vagasRemovidas_codec
        = pb::FieldCodec.ForMessage(10, global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida.Parser);
    private readonly pbc::RepeatedField<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida> vagasRemovidas_ = new pbc::RepeatedField<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasComExcecaoRemovida> VagasRemovidas {
      get { return vagasRemovidas_; }
    }

    /// <summary>Field number for the "motivo" field.</summary>
    public const int MotivoFieldNumber = 2;
    private string motivo_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Motivo {
      get { return motivo_; }
      set {
        motivo_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProcessoVagasComExcecao);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProcessoVagasComExcecao other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!vagasRemovidas_.Equals(other.vagasRemovidas_)) return false;
      if (Motivo != other.Motivo) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= vagasRemovidas_.GetHashCode();
      if (Motivo.Length != 0) hash ^= Motivo.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      vagasRemovidas_.WriteTo(output, _repeated_vagasRemovidas_codec);
      if (Motivo.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Motivo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      vagasRemovidas_.WriteTo(ref output, _repeated_vagasRemovidas_codec);
      if (Motivo.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Motivo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += vagasRemovidas_.CalculateSize(_repeated_vagasRemovidas_codec);
      if (Motivo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Motivo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProcessoVagasComExcecao other) {
      if (other == null) {
        return;
      }
      vagasRemovidas_.Add(other.vagasRemovidas_);
      if (other.Motivo.Length != 0) {
        Motivo = other.Motivo;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            vagasRemovidas_.AddEntriesFrom(input, _repeated_vagasRemovidas_codec);
            break;
          }
          case 18: {
            Motivo = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            vagasRemovidas_.AddEntriesFrom(ref input, _repeated_vagasRemovidas_codec);
            break;
          }
          case 18: {
            Motivo = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class VagasComExcecaoRemovida : pb::IMessage<VagasComExcecaoRemovida>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<VagasComExcecaoRemovida> _parser = new pb::MessageParser<VagasComExcecaoRemovida>(() => new VagasComExcecaoRemovida());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<VagasComExcecaoRemovida> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.ProcessoVagasComExcecaoReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagasComExcecaoRemovida() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagasComExcecaoRemovida(VagasComExcecaoRemovida other) : this() {
      idVaga_ = other.idVaga_;
      descricao_ = other.descricao_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagasComExcecaoRemovida Clone() {
      return new VagasComExcecaoRemovida(this);
    }

    /// <summary>Field number for the "id_vaga" field.</summary>
    public const int IdVagaFieldNumber = 1;
    private int idVaga_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int IdVaga {
      get { return idVaga_; }
      set {
        idVaga_ = value;
      }
    }

    /// <summary>Field number for the "descricao" field.</summary>
    public const int DescricaoFieldNumber = 2;
    private string descricao_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Descricao {
      get { return descricao_; }
      set {
        descricao_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as VagasComExcecaoRemovida);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(VagasComExcecaoRemovida other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IdVaga != other.IdVaga) return false;
      if (Descricao != other.Descricao) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (IdVaga != 0) hash ^= IdVaga.GetHashCode();
      if (Descricao.Length != 0) hash ^= Descricao.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (IdVaga != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(IdVaga);
      }
      if (Descricao.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Descricao);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (IdVaga != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(IdVaga);
      }
      if (Descricao.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Descricao);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (IdVaga != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(IdVaga);
      }
      if (Descricao.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Descricao);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(VagasComExcecaoRemovida other) {
      if (other == null) {
        return;
      }
      if (other.IdVaga != 0) {
        IdVaga = other.IdVaga;
      }
      if (other.Descricao.Length != 0) {
        Descricao = other.Descricao;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            IdVaga = input.ReadInt32();
            break;
          }
          case 18: {
            Descricao = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            IdVaga = input.ReadInt32();
            break;
          }
          case 18: {
            Descricao = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code