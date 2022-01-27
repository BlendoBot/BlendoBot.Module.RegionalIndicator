using BlendoBot.Core.Command;
using BlendoBot.Core.Entities;
using BlendoBot.Core.Module;
using DSharpPlus.EventArgs;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Module.RegionalIndicator;

internal class RegionalIndicatorCommand : ICommand {
	public RegionalIndicatorCommand(RegionalIndicator module) {
		this.module = module;
	}

	private readonly RegionalIndicator module;
	public IModule Module => module;

	public string Guid => "regionalindicator.command";
	public string DesiredTerm => "ri";
	public string Description => "Converts a message into lovely regional indicator text";
	public Dictionary<string, string> Usage => new() {
		{ "[message]", "Regionally indicates this message." }
	};

	public async Task OnMessage(MessageCreateEventArgs e, string[] tokenizedInput) {
		// First covert the original message to lower-case, and remove the original command.
		if (tokenizedInput.Length == 0) {
			await module.DiscordInteractor.Send(this, new SendEventArgs {
				Message = $"You must add something after the {module.ModuleManager.GetCommandTermWithPrefix(this)}!",
				Channel = e.Channel,
				Tag = "RegionalErrorNoMessage"
			});
			return;
		}
		string message = string.Join(' ', tokenizedInput);
		StringBuilder newString = new();
		foreach (char c in message) {
			if (RegionalIndicator.CharacterMappings.ContainsKey(c)) {
				newString.Append(RegionalIndicator.CharacterMappings[c]);
				newString.Append(' '); // Stops platforms from actually rendering flags.
			} else {
				newString.Append(c);
			}
		}
		if (newString.Length <= 2000) {
			await module.DiscordInteractor.Send(this, new SendEventArgs {
				Message = newString.ToString(),
				Channel = e.Channel,
				Tag = "RegionalSuccess"
			});
		} else {
			await module.DiscordInteractor.Send(this, new SendEventArgs {
				Message = $"Regionalified message exceeds maximum character count by {newString.Length - 2000}. Shorten your message!",
				Channel = e.Channel,
				Tag = "RegionalErrorTooLong"
			});
		}
	}
}
