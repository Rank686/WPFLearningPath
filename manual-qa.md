# WPF strict sequential path — QA record

Date: 2026-08-08  
Reviewer: Codex  
Environment: Windows, .NET SDK 10.0.201, `net10.0-windows`

Build and launch evidence:

- `Test-LearningPath.ps1 -SmokeRun` built every Step from an isolated temporary source copy, launched its executable, observed an interactive main-window handle, and closed it normally: 38/38 passed.
- `dotnet build LearningPath/WpfLearningPath.sln -c Release`: 38/38 passed, 0 warnings, 0 errors.
- Runtime assertions are split across `FoundationDataInteractions`, `ValidationInteractions`, `FrameworkInteractions`, and `ApplicationMvvmInteractions`.
- The curriculum validator checked each Step's declared reuse and future-concept exclusions. The five manual first-appearance audits are recorded below the table.

| Step | Built | Launched | Required interaction observed | Future-concept review | Reviewer/date |
|---:|:---:|:---:|---|:---:|---|
| 01 | Yes | Yes | `Hello WPF` rendered from the minimal Window shell. | Pass | Codex / 2026-08-08 |
| 02 | Yes | Yes | StackPanel children rendered top-to-bottom; fixed child width was 180. | Pass | Codex / 2026-08-08 |
| 03 | Yes | Yes | XAML `Click` changed the Button content to `Clicked`. | Pass | Codex / 2026-08-08 |
| 04 | Yes | Yes | XAML handler and C# `+=` handler independently changed their Buttons. | Pass | Codex / 2026-08-08 |
| 05 | Yes | Yes | TextBlock and Button resolved the same `AccentBrush` resource. | Pass | Codex / 2026-08-08 |
| 06 | Yes | Yes | Two TextBlocks received the shared Style setters and resource color. | Pass | Codex / 2026-08-08 |
| 07 | Yes | Yes | Merged dictionary loaded and supplied the same Style at runtime. | Pass | Codex / 2026-08-08 |
| 08 | Yes | Yes | Changing the named TextBox immediately changed the bound TextBlock. | Pass | Codex / 2026-08-08 |
| 09 | Yes | Yes | Explicit object Source displayed `Ada Lovelace`. | Pass | Codex / 2026-08-08 |
| 10 | Yes | Yes | Descendants inherited one Profile DataContext and displayed `Grace Hopper`. | Pass | Codex / 2026-08-08 |
| 11 | Yes | Yes | OneWay left its source false; TwoWay wrote true back to its source. | Pass | Codex / 2026-08-08 |
| 12 | Yes | Yes | PropertyChanged wrote immediately, LostFocus wrote on focus loss, Explicit wrote only after `UpdateSource`. | Pass | Codex / 2026-08-08 |
| 13 | Yes | Yes | Changing only the source property refreshed the OneWay target through INPC. | Pass | Codex / 2026-08-08 |
| 14 | Yes | Yes | Moving the Slider to 40 produced `Current number: 40` through the converter. | Pass | Codex / 2026-08-08 |
| 15 | Yes | Yes | Plain List ItemsSource produced exactly three repeated rows. | Pass | Codex / 2026-08-08 |
| 16 | Yes | Yes | Adding/removing the ObservableCollection changed the visible item count without rebinding. | Pass | Codex / 2026-08-08 |
| 17 | Yes | Yes | ItemTemplate existed; adding a row and toggling the first item's property both propagated. | Pass; DataTemplate first appears here | Codex / 2026-08-08 |
| 18 | Yes | Yes | Previous/Next moved the view CurrentItem and refreshed its label. | Pass; ICollectionView first appears here | Codex / 2026-08-08 |
| 19 | Yes | Yes | Selecting ListBox row 3 moved CurrentItem and the detail ContentControl to the same object. | Pass | Codex / 2026-08-08 |
| 20 | Yes | Yes | Sort changed only the view order; Clear restored source order and the source collection never moved. | Pass | Codex / 2026-08-08 |
| 21 | Yes | Yes | Attaching Filter showed all rows without manual Refresh; changing the captured flag plus Refresh reduced the view to two active rows. | Pass | Codex / 2026-08-08 |
| 22 | Yes | Yes | Group-by-category cleared prior shaping, created two groups, and Clear removed grouping. | Pass | Codex / 2026-08-08 |
| 23 | Yes | Yes | Begin cleared shaping; Commit retained the provisional row; Cancel removed it and both paths cleared the editor. | Pass | Codex / 2026-08-08 |
| 24 | Yes | Yes | Text and negative prices were rejected without source mutation; `25` updated the source. | Pass; ValidationRule first appears here | Codex / 2026-08-08 |
| 25 | Yes | Yes | Cross-field 50/40 failed; 50/60 committed through BindingGroup proposed values. | Pass | Codex / 2026-08-08 |
| 26 | Yes | Yes | Invalid row 1 did not prevent valid row 2 from committing its independent ItemBindingGroup. | Pass | Codex / 2026-08-08 |
| 27 | Yes | Yes | Both derived Styles inherited padding/font; each retained its own Background setter. | Pass | Codex / 2026-08-08 |
| 28 | Yes | Yes | Templated Button preserved Content and Click behavior. | Pass; ControlTemplate first appears here | Codex / 2026-08-08 |
| 29 | Yes | Yes | Invalid age created the custom error presentation/message; valid age cleared it. | Pass; Validation.ErrorTemplate first appears here | Codex / 2026-08-08 |
| 30 | Yes | Yes | DataTrigger changed preview Background and BorderBrush when the CheckBox became true. | Pass | Codex / 2026-08-08 |
| 31 | Yes | Yes | MouseDown bubbled inner→outer; `Handled=true` stopped the ordinary outer handler and Source values were logged. | Pass | Codex / 2026-08-08 |
| 32 | Yes | Yes | CanExecute disabled Save, enabled it after opt-in, and Executed updated status. | Pass | Codex / 2026-08-08 |
| 33 | Yes | Yes | A local Background overrode Style; ClearValue restored the Style value and ReadLocalValue returned UnsetValue. | Pass | Codex / 2026-08-08 |
| 34 | Yes | Yes | Incrementing custom Rating DP immediately updated the bound UI without INPC. | Pass | Codex / 2026-08-08 |
| 35 | Yes | Yes | Coerce ran before changed; unchanged effective value skipped changed; lowering Maximum recoerced to 3. | Pass | Codex / 2026-08-08 |
| 36 | Yes | Yes | OnStartup created MainWindow; ToolWindow resolved the app brush; closing MainWindow shut down the application. | Pass | Codex / 2026-08-08 |
| 37 | Yes | Yes | Typing `Ada` immediately updated VM.Name and the notifying Greeting, with no action command. | Pass | Codex / 2026-08-08 |
| 38 | Yes | Yes | Empty Name disabled Save; `Grace` enabled it; Execute set notifying `Saved: Grace` via VM command. | Pass | Codex / 2026-08-08 |

## First-appearance gates

| Concept | Required first Step | Observed first file |
|---|---:|---|
| DataTemplate | 17 | `Step17-DataTemplate/MainWindow.xaml:21` |
| ICollectionView | 18 | `Step18-CollectionViewCurrentItem/MainWindow.xaml.cs:17` |
| ValidationRule | 24 | `Step24-ValidationRule/MainWindow.xaml:5` |
| ControlTemplate | 28 | `Step28-ControlTemplate/MainWindow.xaml:11` |
| Validation.ErrorTemplate | 29 | `Step29-ValidationErrorTemplate/MainWindow.xaml:15` |

No teaching `.csproj` contains `ProjectReference`, `PackageReference`, or linked source.

## HTML/browser QA

- Static manifest/HTML contract test passed.
- Dependency-free Edge/CDP test passed: 38 unique labeled nodes, 4484px SVG width, horizontal scrolling, default-closed/openable route notes, new progress isolated from the legacy project key, Step locking, refresh persistence, blocked-click protection, cascade removal, corrupted-state normalization, and legacy plan switching.
- Desktop screenshot: `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-1920x1080.png`
- Narrow screenshot: `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-900x1100.png`
- Visual inspection: labels are present inside every visible circle; the curve is unsmoothed and retains difficulty dips; the narrow layout remains readable and the graph remains horizontally scrollable.
- Step37/38 的综合练习链接只引用仓库已跟踪的 `Sample Applications/CustomComboBox/CustomComboBox.csproj`；未依赖工作区中未跟踪的 MvvmDemo 目录。
- Legacy catalog contains 253 projects, and every displayed project path is tracked by Git; the visible combined total is 291.
- Purity scan confirms every lesson introduces exactly its one primary concept, with no Grid, DockPanel, or CallerMemberName syntax in the 38 teaching projects.
- Validator adversarial suite passed all 48 cases, including future-step prefix bypasses, all MSBuild expression forms, semicolon item specs, and nested `originalSamples` schema constraints.

## Theme matrix — provisional 38-step route

The four Edge/CDP captures reset both progress stores before capture, open route notes before selecting the theme, and validate each PNG signature and size before writing. The wide captures keep `#themeMode` focused; the narrow captures center the selected route target. Final 47-step screenshots are required by the reinforcement integration plan.

- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-light-base-1920x1080.png` — inspected: light base route uses the strict 38-step SVG; the focused theme selector is visible, route notes are readable, logo and chart colors retain contrast, labels are not clipped, and only the intended in-map horizontal scroll area overflows.
- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-dark-reinforcement-1920x1080.png` — inspected: dark reinforcement route uses the separately rendered legacy SVG; the focused theme selector remains visible, no pale light-only islands appeared, route notes and labels remain readable, and page-level overflow is absent.
- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-light-base-900x1100.png` — inspected: light base route centers the selected strict-route node; controls, logo, route notes, and visible labels are readable with no page-level overflow beyond the intentional map scroller.
- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-dark-reinforcement-900x1100.png` — inspected: dark reinforcement route renders the legacy SVG cleanly; contrast, controls, route notes, and visible labels remain readable with no pale light-only islands or page-level overflow.

Keyboard check: one `Tab` reached `#themeMode`; `ArrowDown` changed `system` to `light` while it remained the active `:focus-visible` element with its visible outline. The canvas implementation is dormant, so no visible-canvas QA is claimed.

## Final 47-step publication — 2026-08-21

The final Edge/CDP run loaded schema 2 with 47 lessons, selected `Step41-ThemedProfileEditor`, applied the requested theme and viewport, completed all scrolling and layout settling, then opened `details.route-notes` as the final DOM action. It waited two animation frames, asserted the disclosure was still open immediately before and after `Page.captureScreenshot`, and captured a viewport pre-sized to the expanded full-page height. The frozen 38-ID fixture also verified that an existing learner resumes at 38/47 and unlocks Step39 without changing the storage key. These four files were regenerated and visually reinspected on 2026-08-21 after correcting the capture-order regression:

- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-47-expanded-light-themed-profile-editor-1920x1080.png` — Pass: the down-pointing disclosure marker and all nine Route notes cards are visible in a 3-by-3 grid, including reinforcement ranges Step39–41, Step42–44, and Step45–47; the 47-project/300-entry summary, Step41-selected late route, both curves, and all three Track07 lesson cards are also visible.
- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-47-expanded-dark-themed-profile-editor-1920x1080.png` — Pass: the dark full-page image visibly contains the open disclosure and the same nine-card 3-by-3 Route notes grid, Step41 selection, both curves, and three Track07 lesson cards; labels and borders remain readable without light-theme islands.
- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-47-expanded-light-themed-profile-editor-900x1100.png` — Pass: the narrow full-page image visibly contains the open disclosure and all nine Route notes cards in a two-column flow with the ninth card on the final row; the Step38–44 centered route neighborhood, 47 counts, both curves, and the selected Step41 lesson card are visible, with horizontal overflow confined to the route scroller.
- `E:\Users\rank3\AppData\Local\Temp\wpf-learning-progress-47-expanded-dark-themed-profile-editor-900x1100.png` — Pass: the narrow dark image visibly contains the open disclosure, all nine two-column Route notes cards, the Step41-centered route, 47 counts, both curves, and all three Track07 lesson cards; text, semantic borders, and dark surfaces remain readable.

Final interaction evidence: `FoundationDataInteractions` passed Steps39–43 in addition to its concept checks; `ValidationInteractions`, `FrameworkInteractions`, `RatingWorkspaceApplicationInteractions`, and `ApplicationMvvmInteractions` passed the remaining Step44–47 behaviors. The validator reported all 92 cases passed, the canonical wrapper reported `LearningPath Step01-Step47 passed validation.`, and both static and browser HTML suites passed.
