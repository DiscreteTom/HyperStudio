// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: shremdup.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Shremdup {
  public static partial class Shremdup
  {
    static readonly string __ServiceName = "shremdup.Shremdup";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.RestartRequest> __Marshaller_shremdup_RestartRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.RestartRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.RestartReply> __Marshaller_shremdup_RestartReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.RestartReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.ListDisplaysRequest> __Marshaller_shremdup_ListDisplaysRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.ListDisplaysRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.ListDisplaysReply> __Marshaller_shremdup_ListDisplaysReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.ListDisplaysReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.GetDisplayRequest> __Marshaller_shremdup_GetDisplayRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.GetDisplayRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.GetDisplayReply> __Marshaller_shremdup_GetDisplayReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.GetDisplayReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.CreateCaptureRequest> __Marshaller_shremdup_CreateCaptureRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.CreateCaptureRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.CreateCaptureReply> __Marshaller_shremdup_CreateCaptureReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.CreateCaptureReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.DeleteCaptureRequest> __Marshaller_shremdup_DeleteCaptureRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.DeleteCaptureRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.DeleteCaptureReply> __Marshaller_shremdup_DeleteCaptureReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.DeleteCaptureReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.TakeCaptureRequest> __Marshaller_shremdup_TakeCaptureRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.TakeCaptureRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shremdup.TakeCaptureReply> __Marshaller_shremdup_TakeCaptureReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shremdup.TakeCaptureReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shremdup.RestartRequest, global::Shremdup.RestartReply> __Method_Restart = new grpc::Method<global::Shremdup.RestartRequest, global::Shremdup.RestartReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Restart",
        __Marshaller_shremdup_RestartRequest,
        __Marshaller_shremdup_RestartReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shremdup.ListDisplaysRequest, global::Shremdup.ListDisplaysReply> __Method_ListDisplays = new grpc::Method<global::Shremdup.ListDisplaysRequest, global::Shremdup.ListDisplaysReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ListDisplays",
        __Marshaller_shremdup_ListDisplaysRequest,
        __Marshaller_shremdup_ListDisplaysReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shremdup.GetDisplayRequest, global::Shremdup.GetDisplayReply> __Method_GetDisplay = new grpc::Method<global::Shremdup.GetDisplayRequest, global::Shremdup.GetDisplayReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetDisplay",
        __Marshaller_shremdup_GetDisplayRequest,
        __Marshaller_shremdup_GetDisplayReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shremdup.CreateCaptureRequest, global::Shremdup.CreateCaptureReply> __Method_CreateCapture = new grpc::Method<global::Shremdup.CreateCaptureRequest, global::Shremdup.CreateCaptureReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateCapture",
        __Marshaller_shremdup_CreateCaptureRequest,
        __Marshaller_shremdup_CreateCaptureReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shremdup.DeleteCaptureRequest, global::Shremdup.DeleteCaptureReply> __Method_DeleteCapture = new grpc::Method<global::Shremdup.DeleteCaptureRequest, global::Shremdup.DeleteCaptureReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCapture",
        __Marshaller_shremdup_DeleteCaptureRequest,
        __Marshaller_shremdup_DeleteCaptureReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shremdup.TakeCaptureRequest, global::Shremdup.TakeCaptureReply> __Method_TakeCapture = new grpc::Method<global::Shremdup.TakeCaptureRequest, global::Shremdup.TakeCaptureReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "TakeCapture",
        __Marshaller_shremdup_TakeCaptureRequest,
        __Marshaller_shremdup_TakeCaptureReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Shremdup.ShremdupReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Shremdup</summary>
    [grpc::BindServiceMethod(typeof(Shremdup), "BindService")]
    public abstract partial class ShremdupBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Shremdup.RestartReply> Restart(global::Shremdup.RestartRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// get a list of all display infos
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Shremdup.ListDisplaysReply> ListDisplays(global::Shremdup.ListDisplaysRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// get a display info by id
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Shremdup.GetDisplayReply> GetDisplay(global::Shremdup.GetDisplayRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// create a capture
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Shremdup.CreateCaptureReply> CreateCapture(global::Shremdup.CreateCaptureRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// delete a capture
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Shremdup.DeleteCaptureReply> DeleteCapture(global::Shremdup.DeleteCaptureRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// update the capture image and info in the shared memory
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Shremdup.TakeCaptureReply> TakeCapture(global::Shremdup.TakeCaptureRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Shremdup</summary>
    public partial class ShremdupClient : grpc::ClientBase<ShremdupClient>
    {
      /// <summary>Creates a new client for Shremdup</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ShremdupClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Shremdup that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ShremdupClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ShremdupClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ShremdupClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.RestartReply Restart(global::Shremdup.RestartRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Restart(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.RestartReply Restart(global::Shremdup.RestartRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Restart, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.RestartReply> RestartAsync(global::Shremdup.RestartRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RestartAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.RestartReply> RestartAsync(global::Shremdup.RestartRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Restart, null, options, request);
      }
      /// <summary>
      /// get a list of all display infos
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.ListDisplaysReply ListDisplays(global::Shremdup.ListDisplaysRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListDisplays(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// get a list of all display infos
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.ListDisplaysReply ListDisplays(global::Shremdup.ListDisplaysRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ListDisplays, null, options, request);
      }
      /// <summary>
      /// get a list of all display infos
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.ListDisplaysReply> ListDisplaysAsync(global::Shremdup.ListDisplaysRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListDisplaysAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// get a list of all display infos
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.ListDisplaysReply> ListDisplaysAsync(global::Shremdup.ListDisplaysRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ListDisplays, null, options, request);
      }
      /// <summary>
      /// get a display info by id
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.GetDisplayReply GetDisplay(global::Shremdup.GetDisplayRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetDisplay(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// get a display info by id
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.GetDisplayReply GetDisplay(global::Shremdup.GetDisplayRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetDisplay, null, options, request);
      }
      /// <summary>
      /// get a display info by id
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.GetDisplayReply> GetDisplayAsync(global::Shremdup.GetDisplayRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetDisplayAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// get a display info by id
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.GetDisplayReply> GetDisplayAsync(global::Shremdup.GetDisplayRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetDisplay, null, options, request);
      }
      /// <summary>
      /// create a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.CreateCaptureReply CreateCapture(global::Shremdup.CreateCaptureRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateCapture(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// create a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.CreateCaptureReply CreateCapture(global::Shremdup.CreateCaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateCapture, null, options, request);
      }
      /// <summary>
      /// create a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.CreateCaptureReply> CreateCaptureAsync(global::Shremdup.CreateCaptureRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateCaptureAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// create a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.CreateCaptureReply> CreateCaptureAsync(global::Shremdup.CreateCaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateCapture, null, options, request);
      }
      /// <summary>
      /// delete a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.DeleteCaptureReply DeleteCapture(global::Shremdup.DeleteCaptureRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCapture(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// delete a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.DeleteCaptureReply DeleteCapture(global::Shremdup.DeleteCaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteCapture, null, options, request);
      }
      /// <summary>
      /// delete a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.DeleteCaptureReply> DeleteCaptureAsync(global::Shremdup.DeleteCaptureRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCaptureAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// delete a capture
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.DeleteCaptureReply> DeleteCaptureAsync(global::Shremdup.DeleteCaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteCapture, null, options, request);
      }
      /// <summary>
      /// update the capture image and info in the shared memory
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.TakeCaptureReply TakeCapture(global::Shremdup.TakeCaptureRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return TakeCapture(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// update the capture image and info in the shared memory
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shremdup.TakeCaptureReply TakeCapture(global::Shremdup.TakeCaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_TakeCapture, null, options, request);
      }
      /// <summary>
      /// update the capture image and info in the shared memory
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.TakeCaptureReply> TakeCaptureAsync(global::Shremdup.TakeCaptureRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return TakeCaptureAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// update the capture image and info in the shared memory
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shremdup.TakeCaptureReply> TakeCaptureAsync(global::Shremdup.TakeCaptureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_TakeCapture, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ShremdupClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ShremdupClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ShremdupBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Restart, serviceImpl.Restart)
          .AddMethod(__Method_ListDisplays, serviceImpl.ListDisplays)
          .AddMethod(__Method_GetDisplay, serviceImpl.GetDisplay)
          .AddMethod(__Method_CreateCapture, serviceImpl.CreateCapture)
          .AddMethod(__Method_DeleteCapture, serviceImpl.DeleteCapture)
          .AddMethod(__Method_TakeCapture, serviceImpl.TakeCapture).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ShremdupBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Restart, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Shremdup.RestartRequest, global::Shremdup.RestartReply>(serviceImpl.Restart));
      serviceBinder.AddMethod(__Method_ListDisplays, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Shremdup.ListDisplaysRequest, global::Shremdup.ListDisplaysReply>(serviceImpl.ListDisplays));
      serviceBinder.AddMethod(__Method_GetDisplay, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Shremdup.GetDisplayRequest, global::Shremdup.GetDisplayReply>(serviceImpl.GetDisplay));
      serviceBinder.AddMethod(__Method_CreateCapture, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Shremdup.CreateCaptureRequest, global::Shremdup.CreateCaptureReply>(serviceImpl.CreateCapture));
      serviceBinder.AddMethod(__Method_DeleteCapture, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Shremdup.DeleteCaptureRequest, global::Shremdup.DeleteCaptureReply>(serviceImpl.DeleteCapture));
      serviceBinder.AddMethod(__Method_TakeCapture, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Shremdup.TakeCaptureRequest, global::Shremdup.TakeCaptureReply>(serviceImpl.TakeCapture));
    }

  }
}
#endregion
