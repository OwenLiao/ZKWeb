﻿using System;
using ZKWebStandard.Extensions;
using ZKWebStandard.Testing.Events;

namespace ZKWeb.Testing.TestEventHandlers {
	/// <summary>
	/// 在控制台中运行测试使用的事件处理器
	/// </summary>
	internal class TestConsoleEventHandler : ITestEventHandler {
		public void OnAllTestStarting(AllTestStartingInfo info) {
			Console.WriteLine($"starting {info.Runner.Assembly.GetName().Name} tests...");
		}

		public void OnAllTestCompleted(AllTestCompletedInfo info) {
			Console.WriteLine($"complete {info.Runner.Assembly.GetName().Name} tests: " +
				$"{info.Counter.Passed} passed, {info.Counter.Failed} failed, {info.Counter.Skipped} skiped.");
			Console.WriteLine();
		}

		public void OnDebugMessage(DebugMessageInfo info) {
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine($"debug: {info.Message}");
			Console.ResetColor();
		}

		public void OnErrorMessage(ErrorMessageInfo info) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"error: {info.Message}");
			Console.ResetColor();
		}

		public void OnTestFailed(TestFailedInfo info) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"failed: {info.Exception}");
			Console.ResetColor();
		}

		public void OnTestPassed(TestPassedInfo info) {
		}

		public void OnTestSkipped(TestSkippedInfo info) {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"skipped: {info.Exception.Message}");
			Console.ResetColor();
		}

		public void OnTestStarting(TestStartingInfo info) {
			Console.WriteLine($"test: {info.Method.GetFullName()}");
		}
	}
}