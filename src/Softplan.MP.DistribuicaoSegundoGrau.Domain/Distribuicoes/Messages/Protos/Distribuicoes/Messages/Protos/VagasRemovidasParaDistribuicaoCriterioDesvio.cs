// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: VagasRemovidasParaDistribuicaoCriterioDesvio.proto
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
  /// <summary>Holder for reflection information generated from VagasRemovidasParaDistribuicaoCriterioDesvio.proto</summary>
  public static partial class VagasRemovidasParaDistribuicaoCriterioDesvioReflection {

    #region Descriptor
    /// <summary>File descriptor for VagasRemovidasParaDistribuicaoCriterioDesvio.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static VagasRemovidasParaDistribuicaoCriterioDesvioReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjJWYWdhc1JlbW92aWRhc1BhcmFEaXN0cmlidWljYW9Dcml0ZXJpb0Rlc3Zp",
            "by5wcm90byJ3CixWYWdhc1JlbW92aWRhc1BhcmFEaXN0cmlidWljYW9Dcml0",
            "ZXJpb0Rlc3ZpbxI3Cg92YWdhc19yZW1vdmlkYXMYASADKAsyHi5WYWdhUmVt",
            "b3ZpZGFQb3JEZXN2aW9JbnZhbGlkbxIOCgZtb3Rpdm8YAiABKAkiQwodVmFn",
            "YVJlbW92aWRhUG9yRGVzdmlvSW52YWxpZG8SDwoHaWRfdmFnYRgBIAEoBRIR",
            "CglkZXNjcmljYW8YAiABKAlCS6oCSFNvZnRwbGFuLk1QLkRpc3RyaWJ1aWNh",
            "b1NlZ3VuZG9HcmF1LkRvbWFpbi5EaXN0cmlidWljb2VzLk1lc3NhZ2VzLlBy",
            "b3Rvc2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasRemovidasParaDistribuicaoCriterioDesvio), global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasRemovidasParaDistribuicaoCriterioDesvio.Parser, new[]{ "VagasRemovidas", "Motivo" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido), global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido.Parser, new[]{ "IdVaga", "Descricao" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class VagasRemovidasParaDistribuicaoCriterioDesvio : pb::IMessage<VagasRemovidasParaDistribuicaoCriterioDesvio>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<VagasRemovidasParaDistribuicaoCriterioDesvio> _parser = new pb::MessageParser<VagasRemovidasParaDistribuicaoCriterioDesvio>(() => new VagasRemovidasParaDistribuicaoCriterioDesvio());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<VagasRemovidasParaDistribuicaoCriterioDesvio> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasRemovidasParaDistribuicaoCriterioDesvioReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagasRemovidasParaDistribuicaoCriterioDesvio() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagasRemovidasParaDistribuicaoCriterioDesvio(VagasRemovidasParaDistribuicaoCriterioDesvio other) : this() {
      vagasRemovidas_ = other.vagasRemovidas_.Clone();
      motivo_ = other.motivo_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagasRemovidasParaDistribuicaoCriterioDesvio Clone() {
      return new VagasRemovidasParaDistribuicaoCriterioDesvio(this);
    }

    /// <summary>Field number for the "vagas_removidas" field.</summary>
    public const int VagasRemovidasFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido> _repeated_vagasRemovidas_codec
        = pb::FieldCodec.ForMessage(10, global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido.Parser);
    private readonly pbc::RepeatedField<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido> vagasRemovidas_ = new pbc::RepeatedField<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagaRemovidaPorDesvioInvalido> VagasRemovidas {
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
      return Equals(other as VagasRemovidasParaDistribuicaoCriterioDesvio);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(VagasRemovidasParaDistribuicaoCriterioDesvio other) {
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
    public void MergeFrom(VagasRemovidasParaDistribuicaoCriterioDesvio other) {
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

  public sealed partial class VagaRemovidaPorDesvioInvalido : pb::IMessage<VagaRemovidaPorDesvioInvalido>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<VagaRemovidaPorDesvioInvalido> _parser = new pb::MessageParser<VagaRemovidaPorDesvioInvalido>(() => new VagaRemovidaPorDesvioInvalido());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<VagaRemovidaPorDesvioInvalido> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.VagasRemovidasParaDistribuicaoCriterioDesvioReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagaRemovidaPorDesvioInvalido() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagaRemovidaPorDesvioInvalido(VagaRemovidaPorDesvioInvalido other) : this() {
      idVaga_ = other.idVaga_;
      descricao_ = other.descricao_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public VagaRemovidaPorDesvioInvalido Clone() {
      return new VagaRemovidaPorDesvioInvalido(this);
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
      return Equals(other as VagaRemovidaPorDesvioInvalido);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(VagaRemovidaPorDesvioInvalido other) {
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
    public void MergeFrom(VagaRemovidaPorDesvioInvalido other) {
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
